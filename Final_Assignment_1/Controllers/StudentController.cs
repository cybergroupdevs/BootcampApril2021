using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Final_Assignment_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Final_Assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentDBContext _context;
        public StudentController(StudentDBContext context)
        {
            _context = context;
        }
        // GET: api/Students/5
        [HttpGet("{id}")]
        public ActionResult GetStudentById(int id)
        {
            var student = _context.StudentInfo.Where(x => x.Id == id);
            return Ok(student);
        }
        [HttpGet]
        public ActionResult GetAllStudents()
        {
            var list = _context.StudentInfo.ToList();
            return Ok(list);
        }

        // POST: api/Student
        [HttpPost]
        public ActionResult AddStudent([FromBody]StudentInfo student)
        {
            _context.StudentInfo.Add(student);
            _context.SaveChanges();
            return Ok("Student Added");

        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] StudentInfo updateRequest)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            studentInfo.FirstName = updateRequest.FirstName;
            studentInfo.LastName = updateRequest.LastName;
            studentInfo.Address = updateRequest.Address;
            studentInfo.City = updateRequest.City;
            _context.StudentInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            _context.StudentInfo.Remove(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
    }
}
