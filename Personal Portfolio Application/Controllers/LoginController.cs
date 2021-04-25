using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using assignment_net1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace assignment_net1.Controllers
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

        // POST: api/Login
        [AllowAnonymous]
        [HttpPost]
        public IActionResult LoginUser([FromBody] UserLogin login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if(user != null)
            {
                var tokenstring = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenstring });
            }
            return response;
        }

        private string GenerateJSONWebToken(UserLogin userInfo)
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

        private UserLogin AuthenticateUser(UserLogin login)
        {
            UserLogin user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.UserName == "Ishank" && login.Password == "abc@123")
            {
                user = new UserLogin { UserName = "Ishank", Password = "abc@123" };
            }
            return user;
        }
    }
}
