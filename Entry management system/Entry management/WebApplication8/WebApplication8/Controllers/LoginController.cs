using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication8.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication8.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class LoginController : Controller
        {
            GuardContext _context;
            private IConfiguration _config;



            public LoginController(IConfiguration config, GuardContext context)
            {
                _config = config;
                _context = context;
            }



            [HttpGet]
            [Authorize]
            public ActionResult GetLoginFields()
            {
                var userList = _context.LoginUser.ToList();
                return Ok(userList);
            }



            // GET: api/Login/5
            [HttpGet("{id}", Name = "GetLoginByUserName")]
            public ActionResult GetLoginByUserName(string UserName)
            {
                LoginUser login = _context.LoginUser.FirstOrDefault(loginInfo => loginInfo.Email == UserName);
                return Ok(login);
            }



            [AllowAnonymous]
            [Route("[action]")]
            [HttpPost]
            public IActionResult Signup([FromBody] LoginUser login)
            {
                _context.LoginUser.Add(login);
                _context.SaveChanges();
                return Ok("User Added successfully");
            }



            [AllowAnonymous]
            [Route("[action]")]
            [HttpPost]
            public string Login([FromBody] LoginUser login)
            {
                IActionResult response = Unauthorized();
                var loginInfo = AuthenticateLogin(login);



                if (loginInfo != null)
                {
                    var tokenString = GenerateJSONWebToken(loginInfo);
                    return tokenString;
                }
                return "false";
            }



            private string GenerateJSONWebToken(LoginUser userInfo)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);



                return new JwtSecurityTokenHandler().WriteToken(token);
            }



            private LoginUser AuthenticateLogin(LoginUser login)
            {
                LoginUser user = null;



                var loginList = _context.LoginUser.ToList();
                for (int i = 0; i < loginList.Count; i++)
                {
                    if (loginList[i].Email == login.Email && loginList[i].Passwrd == login.Passwrd)
                    {
                        user = login;
                        break;
                    }
                }
                return user;
            }
        }
    }