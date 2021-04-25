using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtractionOfData.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace ExtractionOfData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //Context determine how various operations should be performed.
        BanksContext _context;

        public int FirstName { get; private set; }

        public ValuesController(BanksContext context)

        {
            _context = context;
        }

        //This is default API for getting all students
        [HttpGet]
        public IActionResult AllStudents()
        {
            var students = _context.StudentInfo.ToList();
            return Ok(students);
        }

        //This is designed API for printing student details w.r.t. ID (/api/values/("1/2/3/..")
        [HttpGet("{id}")]
        public IActionResult GetStudentbyId(int Id)
        {
            var student = _context.StudentInfo.FirstOrDefault(studentInfo => studentInfo.Id == Id);
            return Ok(student);
        }


        // This is designed API for Adding details of student in database (POST (/api/values)
        [HttpPost]
        public IActionResult AddStudents([FromBody]StudentRequest studentRequest)
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

        // This is designed API for Changing details of student in database
        [HttpPut("{id}")]
        public IActionResult UpdateStudentDetails(int id, [FromBody]StudentRequest studentRequest)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            studentInfo.FirstName = studentRequest.FirstName;
            studentInfo.LastName = studentRequest.LastName;
            _context.StudentInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }

        // This is designed API for Deleting details of student in database
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int Id)
        {
            var student = _context.StudentInfo.FirstOrDefault(studentInfo => studentInfo.Id == Id);
            _context.StudentInfo.Remove(student);
            _context.SaveChanges();
            return Ok("Student Deleted");
            
        }
     
             
    }
}
