using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentBooks.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AssignmentBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {

        BooksDBContext _context;
       

        public SignupController(BooksDBContext context)
        {
            _context = context;
        }
        // GET: api/Signup
       

        // POST: api/Signup
        [HttpPost]
        public IActionResult createusers([FromBody]Login value)
        {
            var Users = _context.Login.ToList();
            var user = Users.FirstOrDefault(xyz => (xyz.UserName == value.UserName));
            if(user !=null)
            {
                return StatusCode(406);
            }
            else if(value.UserName == "" || value.Passwords == "")
            {
                return StatusCode(406);
            }
            else
            {
                Login Info = new Login();
                Info.UserName = value.UserName;
                Info.Passwords = value.Passwords;
                _context.Login.Add(Info);
                _context.SaveChanges();
                return Ok();
            }

        }

        // PUT: api/Signup/5
        [HttpPut("{id}")]
        public void PuttingUsers(int id, [FromBody]string value)
        {
            

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteingUsers(int id)
        {
        }
    }
}
