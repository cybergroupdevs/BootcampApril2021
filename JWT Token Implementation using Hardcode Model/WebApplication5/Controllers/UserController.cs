using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        UserDBContext _context;

        public UserController(UserDBContext context)
        {
            _context = context;
        }

        private IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserModel login)
        {
            IActionResult response = Unauthorized();
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
            UserModel user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.Username == "Jignesh")
            {
                user = new UserModel { Username = "Jignesh Trivedi", EmailAddress = "test.btest@gmail.com" };
            }
            return user;
        }

        [System.Web.Http.HttpPost]
        public ActionResult AddUser([FromBody] UserInfo user)
        {
            _context.UserInfo.Add(user);
            _context.SaveChanges();
            return Ok("User Details Added successfully");
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var studentList = _context.UserInfo.ToList();
            return Ok(studentList);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            UserInfo userInfo = _context.UserInfo.FirstOrDefault(user => user.Id == id);
            return Ok(userInfo);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] UserInfo UserRequest)
        {
            UserInfo userInfo = _context.UserInfo.FirstOrDefault(user => user.Id == id);
            userInfo.FirstName = UserRequest.FirstName;
            userInfo.LastName = UserRequest.LastName;
            userInfo.Age = UserRequest.Age;
            userInfo.Address = UserRequest.Address;
            _context.UserInfo.Update(userInfo);
            _context.SaveChanges();
            return Ok(userInfo);
        }

       

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var UserInfo = _context.UserInfo.FirstOrDefault(user => user.Id == id);
            _context.UserInfo.Remove(UserInfo);
            _context.SaveChanges();
            return Ok(UserInfo);
        }
    }
}