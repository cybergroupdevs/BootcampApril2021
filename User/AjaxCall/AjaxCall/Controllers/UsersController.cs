using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApplication.Models;

namespace UsersApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        UserDBContext _context;
        public UsersController(UserDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = _context.UserInfo.ToList();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult UserById(int id)
        {
            var user = _context.UserInfo.FirstOrDefault(studentInfo => studentInfo.Id == id);
            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult NewUser([FromBody] UserInfo user)
        {
            _context.UserInfo.Add(user);
            _context.SaveChanges();
            return Ok("User added successfully");
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserInfo UserUpdated)
        {
            UserInfo UserInfo = _context.UserInfo.FirstOrDefault(student => student.Id == id);
            UserInfo.FirstName = UserUpdated.FirstName;
            UserInfo.LastName = UserUpdated.LastName;
            UserInfo.Age = UserUpdated.Age;
            UserInfo.Address = UserUpdated.Address;
            _context.UserInfo.Update(UserInfo);
            _context.SaveChanges();
            return Ok("Updated");
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.UserInfo.FirstOrDefault(UserInfo => UserInfo.Id == id);
            _context.UserInfo.Remove(user);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
