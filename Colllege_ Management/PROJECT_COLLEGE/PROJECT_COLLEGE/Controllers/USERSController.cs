using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PROJECT_COLLEGE.Models;

namespace PROJECT_COLLEGE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class USERSController : ControllerBase
    {
        private IConfiguration _config;



        public USERSController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult Login([FromBody]UserTable log)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(log);



            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }



            return response;
        }



        private string GenerateJSONWebToken(UserTable userInfo)
        {
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        private UserTable AuthenticateUser(UserTable log)
        {
            UserTable user = null;



            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (log.UserName == "bhavaana")
            {
                user = new UserTable { UserName = "bhavaana",Password = "9876" };
            }
            return user;
        }
    }
}
