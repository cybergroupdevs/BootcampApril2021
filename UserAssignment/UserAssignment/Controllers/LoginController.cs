using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UserAssignment.Models;
using UserAssignment.Models.LoginModel;

namespace UserAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        UserDBContext _context;
        private IConfiguration _config;

        public LoginController(IConfiguration config, UserDBContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetLoginFields()
        {
            var userList = _context.Login.ToList();
            return Ok(userList);
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "GetLoginByUserName")]
        public ActionResult GetLoginByUserName(string UserName)
        {
            Login login = _context.Login.FirstOrDefault(loginInfo => loginInfo.UserName == UserName);
            return Ok(login);
        }

        [AllowAnonymous]
        [Route("[action]")]
        [HttpPost]
        public IActionResult Signup([FromBody]Login login)
        {
            _context.Login.Add(login);
            _context.SaveChanges();
            return Ok("User Added successfully");
        }

        [AllowAnonymous]
        [Route("[action]")]
        [HttpPost]
        public string Login([FromBody]Login login)
        {
            IActionResult response = Unauthorized();
            var loginInfo = AuthenticateLogin(login);

            if(loginInfo != null)
            {
                var tokenString = GenerateJSONWebToken(loginInfo);
                return tokenString;
            }
            return "false";
        }

        private string GenerateJSONWebToken(Login userInfo)
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

        private Login AuthenticateLogin(Login login)
        {
            Login user = null;

            var loginList = _context.Login.ToList();
            for (int i = 0; i < loginList.Count; i++)
            {
                if (loginList[i].UserName == login.UserName && loginList[i].Password == login.Password)
                {
                    user = login;
                    break;
                }
            }
            return user;
        }
    }
}