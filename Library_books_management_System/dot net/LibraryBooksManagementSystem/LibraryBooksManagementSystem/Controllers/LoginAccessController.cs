using LibraryBooksManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LibraryBooksDBContext _context;
        private IConfiguration _config;

        public LoginController(IConfiguration config, LibraryBooksDBContext context)
        {
            _context = context;
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public string Login([FromBody]Login login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                return tokenString;
            }

            return "false";
        }
        [HttpGet]
        public ActionResult GetLoginFeed()
        {
            var UserList = _context.Login.ToList();
            return Ok(UserList);
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

        private Login AuthenticateUser(Login login)
        {
            var authUser = _context.Login.FirstOrDefault(userInfo => userInfo.UserId == login.UserId);
            Login user = null;




            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.UserId == authUser.UserId && login.Password == authUser.Password)
            {
                user = new Login { UserId = login.UserId};
            }
            return user;
        }

        //private Login AuthenticateUser(Login login)
        //{
        //    Login user = null;
        //    var LoginList = _context.Login.ToList();
        //    for(int i = 0; i < LoginList.Capacity; i++)
        //    {
        //        if (LoginList[i].UserId == login.UserId && LoginList[i].Password == login.Password)
        //        {

        //            user = login;
        //            break;
        //        }
        //        else
        //        {
        //            user = null;
        //        }

        //    }
        //    return user;
        //}
    }
}