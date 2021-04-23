using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDBController : ControllerBase
    {
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
       

        // GET api/<StudentDBController>/5
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.StudentInfo.FirstOrDefault(studentInfo => studentInfo.Id == id);
            return Ok(student);
        }

        // POST api/<StudentDBController>
        [HttpPost]
        public IActionResult AddNewStudent([FromBody] StudentInfo student)
        {
            _context.StudentInfo.Add(student);
            _context.SaveChanges();
            return Ok("Student added successfully");
        }

        // PUT api/<StudentDBController>/5
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

        // DELETE api/<StudentDBController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student= _context.StudentInfo.FirstOrDefault(studentInfo => studentInfo.Id == id);
            _context.StudentInfo.Remove(student);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
