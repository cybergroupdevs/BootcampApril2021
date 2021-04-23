using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assign2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assign2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        StudentDBContext _context;
        public UserController(StudentDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetStudents()
        {
            var studentList = _context.StudentInfo.ToList();
            return Ok(studentList);
        }

        // GET: api/User
        [HttpGet("{id}", Name = "Get")]
        public StudentInfo GetUserByID(int id)
        {
            var user = _context.StudentInfo.FirstOrDefault(studentInfo => studentInfo.Id == id);
            return user;
        }

        // POST: api/User
        [HttpPost]
        public ActionResult AddStudent([FromBody]StudentRequest student)
        {
            StudentInfo temp = new StudentInfo() {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Address = student.Address,
                City = student.City
            };
            _context.StudentInfo.Add(temp);
            _context.SaveChanges();
            return Ok("Student Added successfully");
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] StudentRequest userRequest)
        {
            StudentInfo studentInfo = GetUserByID(id);
            studentInfo.FirstName = userRequest.FirstName;
            studentInfo.LastName = userRequest.LastName;
            studentInfo.Address = userRequest.Address;
            studentInfo.City = userRequest.City;
            _context.SaveChanges();
            return Ok("student updated!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var demo = GetUserByID(id);
            _context.StudentInfo.Remove(demo);
            _context.SaveChanges();
            return Ok(demo);
        }
    }
}
