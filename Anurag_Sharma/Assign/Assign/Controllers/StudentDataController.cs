using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assign.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assign.Controllers
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
        public ActionResult GetStudents()
        {
            var studentList = _context.StudentInfo.ToList();
            return Ok(studentList);
        }

        // GET: api/StudentData/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/StudentData
        [HttpPost]
        public ActionResult AddStudent([FromBody]StudentInfo student)
        {
            _context.StudentInfo.Add(student);
            _context.SaveChanges();
            return Ok("Student Added successfully");
        }

        // PUT: api/StudentData/5
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] StudentInfo studentRequest)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            studentInfo.FirstName = studentRequest.FirstName;
            studentInfo.LastName = studentRequest.LastName;
            _context.StudentInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult DeleteStudentByID(int id)
        {
            var student = _context.StudentInfo.FirstOrDefault(studentInfo => studentInfo.Id == id);
            _context.StudentInfo.Remove(student);
            _context.SaveChanges();
            return Ok(student);
        }
    }
}
