using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HospitalApplication.Controllers
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
        public Object Login([FromBody]Logininfo login)
        {
            IActionResult response;
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });


                return response;
            }
            else
                return new { token = "" }; //agar null hoga to unauthorized return hoga
        }
        private string GenerateJSONWebToken(Logininfo loginInfo)
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

        private Logininfo AuthenticateUser(Logininfo login)
        {
            Logininfo user = null;
            UsersDataContext _context = new UsersDataContext();
            //hamare pure table mein check krega (whether present or not)
            //_context.StudentInfo.Where(e => e.Email == login.EmailAddress && e.Password == login.Password);
            // ya pheli entry aaye ya null
            //Student mein database wala saman hai.
            var Student = _context.Logininfo.SingleOrDefault(e => e.EmailId == login.EmailId && e.Password == login.Password);
            if (Student == null)
            {
                return null;
            }
            user = new Logininfo();
            //UserModel mein ui wala saman hoga
            user.EmailId = user.EmailId;
            user.Password = user.Password;


            return user;
            //Validate the User Credentials 
            //Demo Purpose, I have Passed HardCoded User Information    
        }
    }
}