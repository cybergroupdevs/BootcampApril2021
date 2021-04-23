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
using UserDemo.DbModels;
using UserDemo.Models;

namespace UserDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        StudentDBContext _context;

        IConfiguration _config;

        public LoginController(IConfiguration config, StudentDBContext context)
        {
            _context = context;
            _config = config;
        }


        // POST: api/Login

        [HttpPost]
        public ActionResult AddUser([FromBody] UserModel userModel)
        {
            UserInfo userInfo = new UserInfo()
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                Password = userModel.Password
            };
            _context.UserInfo.Add(userInfo);
            _context.SaveChanges();
            return Ok("User Added");
        }


        [Route("[action]")]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] UserModel login)
        {
            ActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
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

        private UserModel AuthenticateUser(UserModel login)
        {
            var authUser = _context.UserInfo.FirstOrDefault(userInfo => userInfo.UserName == login.UserName);
            UserModel user = null;
            

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.UserName == authUser.UserName)
            {
                user = new UserModel { UserName = login.UserName, Email = login.Email };
            }
            return user;
        }
        // GET: api/Login
        [HttpGet]
        public ActionResult Get()
        {
            var user = _context.UserInfo.ToList();
            return Ok(user);
        }

        //// GET: api/Login/5
        //[Route("[action]")]
        //[HttpGet("{id}", Name = "Get")]
        //public UserInfo GetUser(string userName)
        //{
        //    var user = _context.UserInfo.FirstOrDefault(userInfo => userInfo.UserName == userName);
        //    return user;
        //}

        //// POST: api/Login
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

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
