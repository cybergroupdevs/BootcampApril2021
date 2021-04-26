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
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public object Login([FromBody]LoginInfo login)
        {
            IActionResult response;
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
                return response;
            }

            return new { token = "" };   //agar null hoga to unauthorized return hoga 401
        }

        private string GenerateJSONWebToken(LoginInfo userInfo)
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

        private LoginInfo AuthenticateUser(LoginInfo login)
        {
            //StuInfo is coz we will return entity 
            LoginInfo user = null;
            ProjectDBContext _context = new ProjectDBContext();
            //hamare pure table mein check krega (whether present or not)
            //_context.StudentInfo.Where(e => e.Email == login.EmailAddress && e.Password == login.Password);
            //             ya pheli entry aaye ya null
            //Student mein database wala saman hai.
            var Person = _context.LoginInfo.SingleOrDefault(e => e.InternId == login.InternId && e.Password == login.Password);
            if (Person == null)
            {
                return null;
            }
            user = new LoginInfo();
            //UserModel mein postman wala saman hoga
            user.InternId = Person.InternId;
            user.Password = Person.Password;

            return user;
            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information        
        }
    }
}