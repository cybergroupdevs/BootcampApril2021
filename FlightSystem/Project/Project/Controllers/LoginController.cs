using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        FlightContext _Context;
        private IConfiguration _config;
        public LoginController(FlightContext context, IConfiguration config)
        {
            _Context = context;
            _config = config;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginRequest temp)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(temp);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private object GenerateJSONWebToken(object user)
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

        private Flightlogin AuthenticateUser(LoginRequest login)
        {
            // UserInfo user = null;
            var Users = _Context.Flightlogin.ToList();
            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    

            var user = Users.FirstOrDefault(x => (x.UserName == login.UserName) && (x.Password == login.Password));
            return user;
        }
    }
}
