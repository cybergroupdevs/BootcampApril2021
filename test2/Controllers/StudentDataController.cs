using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test2.Models;

namespace test2.Controllers
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
        public ActionResult GetAll()
        {
            var studentlist = _context.StudentInfo.ToList();
            return Ok(studentlist);

        }

        // GET: api/StudentData/5
        [HttpGet("{id}")]
        public ActionResult Get(int Id)
        {
            var studentlist = _context.StudentInfo.Where(x => x.Id == Id);
            return Ok(studentlist);

        }

        // POST: api/StudentData
        [HttpPost]
        public ActionResult Post([FromBody]StudentInfo student)
        {
            _context.StudentInfo.Add(student);
            _context.SaveChanges();
            return Ok("student added");

        }

        // PUT: api/StudentData/5
        [HttpPut("{id}")]
        public ActionResult Put(int Id, [FromBody]StudentInfo studentRequest)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == Id);
            studentInfo.FirstName = studentRequest.FirstName;
            studentInfo.LastName = studentRequest.LastName;
            studentInfo.Address = studentRequest.Address;
            studentInfo.City = studentRequest.City;
            _context.StudentInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int Id)
        {
            var student_del = _context.StudentInfo.FirstOrDefault(student => student.Id == Id);
            _context.StudentInfo.Remove(student_del);
            _context.SaveChanges();
            return Ok("Student deleted");
        }
    }
}
