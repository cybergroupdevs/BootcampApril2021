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
using Rmsportal.Models;

namespace Rmsportal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        RmsContext _Context;
        private IConfiguration _config;

        public LoginController(RmsContext context, IConfiguration config)
        {
            _Context = context;
            _config = config;
        }

        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // POST: api/Login
        [HttpPost]
        public IActionResult Post([FromBody]loginRequest value)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(value);

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

        private object AuthenticateUser(loginRequest temp)
        {
            var Users = _Context.Clogin.ToList();
            var user = Users.FirstOrDefault(x => (x.UserName == temp.UserName) && (x.Password == temp.Password));
            return user;
        }
    }
}
