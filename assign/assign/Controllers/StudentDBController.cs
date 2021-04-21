using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assign.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace assign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentDBController : ControllerBase
    {
        StudentDBContext _Context;

    public StudentDBController(StudentDBContext context)
    {
        _Context = context;
    }
        // GET: api/StudentDB
        [HttpGet]
        public IActionResult GetStudents()
        {
            var studentList = _Context.StudentInfo.ToList();
            return Ok(studentList); 
        }

        // GET: api/StudentDB/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
        var studentList = _Context.StudentInfo.Where(x => x.Id == id);
        return Ok(studentList);
        }

        // POST: api/StudentDB
        [HttpPost]
        public IActionResult AddStudent([FromBody]studentRequest student)
        {
            StudentInfo studentInfo = new StudentInfo();
            studentInfo.FirstName = student.FirstName;
            studentInfo.LastName = student.LastName;
            studentInfo.Address = student.Address;
            studentInfo.City = student.City;
            _Context.StudentInfo.Add(studentInfo);
            _Context.SaveChanges();
            return Ok("Student Added successfully");
        }

        // PUT: api/StudentDB/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] studentRequest student)
        {

            StudentInfo studentInfo = _Context.StudentInfo.FirstOrDefault(std => std.Id == id);
            studentInfo.FirstName = student.FirstName;
            studentInfo.LastName = student.LastName;
            studentInfo.Address = student.Address;
            studentInfo.City = student.City;
            _Context.StudentInfo.Update(studentInfo);
            _Context.SaveChanges();
            return Ok(studentInfo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student_one = _Context.StudentInfo.FirstOrDefault( Std => Std.Id == id);
            _Context.StudentInfo.Remove(student_one);
            _Context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
