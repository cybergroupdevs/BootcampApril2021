using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        FlightContext _context;
        public SignUpController(FlightContext context)
        {
            _context = context;
        }

        
        // POST: api/SignUp
        [HttpPost]
        public IActionResult Createuser([FromBody] LoginRequest temp)
        {
            var users = _context.Flightlogin.ToList();
            var user = users.FirstOrDefault(x => (x.UserName == temp.UserName));
            if(user != null)
            {
                return StatusCode(406);
            }
            else if(temp.UserName == "" || temp.Password =="")
            {
                return StatusCode(406);
            }
            else
            {
                Flightlogin Info = new Flightlogin();
                Info.UserName = temp.UserName;
                Info.Password = temp.Password;
                Info.Email = temp.Email;
                _context.Flightlogin.Add(Info);
                _context.SaveChanges();
                return Ok();
            }

        }
    }
}
