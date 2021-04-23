using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserDBContext _context;
        public UserController(UserDBContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult ListOfAllUsers()
        {
            var UserList = _context.UsersTable.ToList();
            return Ok(UserList);

        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult ListOfUserByID(int id)
        {
            var UserList = _context.UsersTable.ToList();
            return Ok(UserList.FirstOrDefault(TempUser => TempUser.Id == id));
        }

        // POST: api/User
        [HttpPost]
        public IActionResult AddUser([FromBody] UserTableInfo TempUser)
        {
            UsersTable User = new UsersTable();
            User.FirstName = TempUser.FirstName;
            User.LastName = TempUser.LastName;
            User.Age = TempUser.Age;
            User.Address = TempUser.Address;
            _context.UsersTable.Add(User);
            _context.SaveChanges();
            return Ok("Added new user "+TempUser);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult UpdateUserById(int id, [FromBody]  UserTableInfo TempUser)
        {
            UsersTable User = _context.UsersTable.FirstOrDefault(student => student.Id == id);
            User.FirstName = TempUser.FirstName;
            User.LastName = TempUser.LastName;
            User.Age = TempUser.Age;
            User.Address = TempUser.Address;
            _context.UsersTable.Update(User);
            _context.SaveChanges();
            return Ok("updated user"+TempUser);
            }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UsersTable User = _context.UsersTable.FirstOrDefault(student => student.Id == id);
            _context.Remove(User);
            _context.SaveChanges();
            return Ok("Record Deleted"+User);
        }
    }
}
