using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Assignment.Models;


namespace Assignment.Controllers
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


        [HttpPost]
        public ActionResult AddStudent([FromBody] studentRequest student)
        {
            StudentInfo studentInfo = new StudentInfo();
            studentInfo.FirstName = student.FirstName;
            studentInfo.LastName = student.LastName;
            studentInfo.Address = student.Address;
            studentInfo.City = student.City;
            _context.StudentInfo.Add(studentInfo);
            _context.SaveChanges();
            return Ok("Student Added successfully");
        }


        [HttpGet]
        public ActionResult GetStudents()
        {
            var studentList = _context.StudentInfo.ToList();
            return Ok(studentList);
        }

        // GET: api/StudentDB/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var studentList = _context.StudentInfo.Where(x => x.Id == id);
            return Ok(studentList);
        }


        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] StudentInfo studentRequest)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            studentInfo.FirstName = studentRequest.FirstName;
            studentInfo.LastName = studentRequest.LastName;
            studentInfo.Address = studentRequest.Address;
            studentInfo.City = studentRequest.City;
            _context.StudentInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            _context.StudentInfo.Remove(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
    }
}