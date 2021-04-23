using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
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
        // GET: api/Student
        
        [HttpGet]
        public ActionResult Get()
        {
            var student = _context.StudentInfo.ToList();
            return Ok(student);
        }




        // GET: api/Student/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            StudentInfo student_one = _context.StudentInfo.FirstOrDefault(std => std.Id == id);
            return Ok(student_one);
        }




        [HttpPost]
        public ActionResult AddStudent([FromBody]StudentRequest student)
        {
            StudentInfo student_one = new StudentInfo();
            student_one.FirstName = student.FirstName;
            student_one.LastName = student.LastName;
            student_one.Address = student.Address;
            student_one.City = student.City;
            _context.StudentInfo.Add(student_one);
            _context.SaveChanges();
            return Ok("Student Added successfully");
        }


        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentRequest Temp)
        {
            StudentInfo sI = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            sI.FirstName = Temp.FirstName;
            sI.LastName = Temp.LastName;
            sI.Address = Temp.Address;
            sI.City = Temp.City;
            _context.StudentInfo.Update(sI);
            _context.SaveChanges();
            return Ok("Added");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student_one = _context.StudentInfo.FirstOrDefault(std => std.Id == id);
            _context.StudentInfo.Remove(student_one);
            _context.SaveChanges();
            return Ok("deleted");
        }
    }
}
