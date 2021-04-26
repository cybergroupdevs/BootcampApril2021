using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBooking.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    { 
           bookingportalContext _Context;
            private IConfiguration _config;
    public LoginController(bookingportalContext context, IConfiguration config)
    {
        _Context = context;
        _config = config;
    }



    [HttpPost]
    public IActionResult Login([FromBody] Logins temp)
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



    private Logins AuthenticateUser(Logins login)
    {
        // UserInfo user = null;
        var Users = _Context.Logins.ToList();
        //Validate the User Credentials
        //Demo Purpose, I have Passed HardCoded User Information



        var user = Users.FirstOrDefault(x => (x.Username == login.Username) && (x.Password == login.Password));
        return user;
    }
}
}