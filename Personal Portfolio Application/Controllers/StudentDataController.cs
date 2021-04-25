using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment_net1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_net1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDataController : ControllerBase
    {
        StudentDBContext _context;
        public StudentDataController(StudentDBContext context)
        {
            _context = context;
        }

        // GET: api/StudentData
        [HttpGet]
        [Authorize]
        public IActionResult GetStudents()
        {
            var studentList = _context.StudentInfo.ToList();
            return Ok(studentList);
        }

        // GET: api/StudentData/5
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.StudentInfo.FirstOrDefault(StudentInfo => StudentInfo.Id == id);
            return Ok(student);
        }

        // POST: api/StudentData
        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentRequest temp)
        {
            StudentInfo student = new StudentInfo();
            student.FirstName = temp.FirstName;
            student.LastName = temp.LastName;
            student.Address = temp.Address;
            student.City = temp.City;
            _context.StudentInfo.Add(student);
            _context.SaveChanges();
            return Ok("Student Added Successfully");
        }

        // PUT: api/StudentData/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentRequest temp)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            studentInfo.FirstName = temp.FirstName;
            studentInfo.LastName = temp.LastName;
            studentInfo.Address = temp.Address;
            studentInfo.City = temp.City;
            _context.StudentInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.StudentInfo.FirstOrDefault(Student => Student.Id == id);
            _context.StudentInfo.Remove(student);
            _context.SaveChanges();
            return Ok(student);
        }
    }
}
