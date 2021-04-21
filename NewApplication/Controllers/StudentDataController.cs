using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDataController : ControllerBase
    {
        StudentDBContext _context;
        // GET: api/<StudentDataController>

        public StudentDataController(StudentDBContext context)
        {

            _context = context;
        }
        [HttpGet]
        public ActionResult GetStudentInfo()
        {
            var list1 = _context.StudentInfo.ToList();
            return Ok(list1);
        }


        

        // POST api/<StudentDataController>
        [HttpPost]
        public ActionResult AddStudent([FromBody]StudentInfo student)
        {
            _context.StudentInfo.Add(student);
            _context.SaveChanges();
            return Ok("Student Added Successfully");
        }

        
        
            [HttpPut("{id}")]
            public IActionResult UpdateByID(int id, [FromBody] StudentInfo Temp)
            {
                StudentInfo student_one = _context.StudentInfo.FirstOrDefault(Student => Student.Id == id);
                student_one.FirstName = Temp.FirstName;
                student_one.LastName = Temp.LastName;
                student_one.Address = Temp.Address;
                student_one.City = Temp.City;
                _context.StudentInfo.Update(student_one);
                _context.SaveChanges();
                return Ok("Updated");
            }




        

        // DELETE api/<StudentDataController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudentRecord(int id)
        {
            var student = _context.StudentInfo.FirstOrDefault(StudentInfo => StudentInfo.Id == id);
            _context.StudentInfo.Remove(student);
            _context.SaveChanges();
            return Ok("Student Deleted");
        }
    }
}
