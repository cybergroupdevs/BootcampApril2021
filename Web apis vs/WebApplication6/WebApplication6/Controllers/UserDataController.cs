using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        UsersContext _context;
        public UserDataController(UsersContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _context.UsersTable.ToList();
            return Ok(students);
        }


        // GET api/<StudentDBController>/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var student = _context.UsersTable.FirstOrDefault(studentInfo => studentInfo.Id == id);
            return Ok(student);
        }

        // POST api/<StudentDBController>
        [HttpPost]
        public IActionResult AddNewUser([FromBody]   UsersTable student)
        {
            _context.UsersTable.Add(student);
            _context.SaveChanges();
            return Ok("User added successfully");
        }

        // PUT api/<StudentDBController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UsersTable studentUpdated)
        {
            UsersTable studentInfo = _context.UsersTable.FirstOrDefault(student => student.Id == id);
            studentInfo.FirstName = studentUpdated.FirstName;
            studentInfo.LastName = studentUpdated.LastName;
            studentInfo.Age = studentUpdated.Age;
            studentInfo.Address = studentUpdated.Address;
            _context.UsersTable.Update(studentInfo);
            _context.SaveChanges();
            return Ok("Updated");


        }

        // DELETE api/<StudentDBController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var student = _context.UsersTable.FirstOrDefault(studentInfo => studentInfo.Id == id);
            _context.UsersTable.Remove(student);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}