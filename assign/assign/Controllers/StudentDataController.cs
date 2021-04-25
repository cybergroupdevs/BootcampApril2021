using assign.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDataController : ControllerBase
    {
        NETContext _context;

        public int Id { get; private set; }

        public StudentDataController(NETContext context)
        {
            _context = context;
        }
        // GET: api/<StudentDataController>
        [HttpGet]
        public ActionResult GetStudents()
        {
            var studentList = _context.StudentInfo.ToList();
            return Ok(studentList);
        }

        // GET api/<StudentDataController>/5
        [HttpGet("{id}")]
        public ActionResult GetById(int Id)
        {
            var studentList = _context.StudentInfo.Where(x => x.Id == Id);
            return Ok(studentList);
        }

        // POST api/<StudentDataController>
        [HttpPost]
        public ActionResult AddStudent([FromBody] StudentRequest student_one)
        {
            StudentInfo student = new StudentInfo();
            student.FirstName = student_one.FirstName;
            student.LastName = student_one.LastName;
            student.Address = student_one.Address;
            student.City = student_one.City;
            _context.StudentInfo.Add(student);
            _context.SaveChanges();
            return Ok("Student Added Successfully");
        }

        // PUT api/<StudentDataController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentRequest studentRequest)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            studentInfo.FirstName = studentRequest.FirstName;
            studentInfo.LastName = studentRequest.LastName;
            studentInfo.Address = studentRequest.Address;
            studentInfo.City = studentRequest.City;
            _context.StudentInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok("Student Updated");
        }

        // DELETE api/<StudentDataController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteStudentById(int id)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            _context.StudentInfo.Remove(studentInfo);
            _context.SaveChanges();
            return Ok("Student Deleted");
        }
    }
}
