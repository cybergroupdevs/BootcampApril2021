using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testProject.Models;

namespace testProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentdBContext _context;
        public StudentController(StudentdBContext context)
        {
            _context = context;
        }
        // GET: api/Student
        [HttpGet]
        public ActionResult  AllStudents()
        {
            var students = _context.StudentInfo.ToList();
            return Ok(students);
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public ActionResult StudentsById(int id)
        {
            var student = _context.StudentInfo.FirstOrDefault(studentInfo => studentInfo.Id == id);
            return Ok(student);
            //return "value";
        }

        // POST: api/Student
        [HttpPost]
        public ActionResult AddStudent([FromBody]StudentRequest studentRequest)
        {
            StudentInfo studentInfo = new StudentInfo()
            {
                FirstName = studentRequest.FirstName,
                LastName = studentRequest.LastName,
                Address = studentRequest.Address,
                City = studentRequest.City

            };

            _context.StudentInfo.Add(studentInfo);
            _context.SaveChanges();
            return Ok("Student Added");
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int  id, [FromBody] StudentRequest studentRequest)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            studentInfo.FirstName = studentRequest.FirstName;
            studentInfo.LastName = studentRequest.LastName;
            studentInfo.Address = studentRequest.Address;
            studentInfo.City = studentRequest.City;
            //_context.StudentInfo.Update(studentInfo);
            _context.SaveChanges();

            return Ok("Student Updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
       public ActionResult DeleteStudent(int id)
        {
            var student = _context.StudentInfo.FirstOrDefault(studentInfo => studentInfo.Id == id);
            _context.StudentInfo.Remove(student);
            _context.SaveChanges();

            return Ok(student);
       }
    }
}
