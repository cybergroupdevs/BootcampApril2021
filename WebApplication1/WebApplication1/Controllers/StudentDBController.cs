using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDBController : ControllerBase
    {
        // GET: api/StudentDB
        StudentDBContext _context;
        public StudentDBController(StudentDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _context.StudentInfo.ToList();
            return Ok(students);
        }
       
        // GET: api/StudentDB/5
        /*[HttpGet("{id}", Name = "Get")]
 
        public IActionResult GetStudentById(int id)
        {
            var student = _context.StudentInfo.FirstOrDefault(studentInfo => studentInfo.Id == id);
            return Ok(student);
        }*/
       
        // POST: api/StudentDB
        [HttpPost]
        public IActionResult AddNewStudent([FromBody] StudentInfo student)
        {
            _context.StudentInfo.Add(student);
            _context.SaveChanges();
            return Ok("Student added successfully");
        }

        // PUT: api/StudentDB/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StudentInfo studentUpdated)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            studentInfo.FirstName = studentUpdated.FirstName;
            studentInfo.LastName = studentUpdated.LastName;
            _context.StudentInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok("Updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.StudentInfo.FirstOrDefault(studentInfo => studentInfo.Id == id);
            _context.StudentInfo.Remove(student);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
