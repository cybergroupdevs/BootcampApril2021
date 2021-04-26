using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentBooks.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AssignmentBooks.Controllers
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

        // GET: api/Login
        [HttpGet]
        public ActionResult<IEnumerable<string>> toGet()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public string toGetId(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult postLogin([FromBody]Login login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);
            if(user!=null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            
            return response;
        }

        private string GenerateJSONWebToken(Login userInfo)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
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
            Login user = null;
            if(login.UserName =="Jignesh")
            {
                user = new Login { UserName = "Jignesh", Passwords = "text.btest" };
            }
            return user;
        }


        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
