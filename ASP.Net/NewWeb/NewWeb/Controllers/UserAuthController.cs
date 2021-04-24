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
using NewWeb.Models;

namespace NewWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {

        StudentDBContext _Context;
        private IConfiguration _config;
        public UserAuthController(StudentDBContext context, IConfiguration config)
        {
            _Context = context;
            _config = config;
        }
        

        // POST: api/UserAuth
        [HttpPost]
        public IActionResult Login([FromBody]UserInfo temp)
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

        private AuthUser AuthenticateUser(UserInfo login)
        {
           // UserInfo user = null;
            var Users = _Context.AuthUser.ToList();
            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    

            var user = Users.FirstOrDefault(x => (x.UserName == login.UserName) && (x.password_==login.password_));
            return user;
        }

        
    }
}
