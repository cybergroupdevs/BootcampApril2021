using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
//using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWeb.Models;

namespace NewWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsDataController : ControllerBase
    {
        StudentDBContext _Context;
        public  StudentsDataController(StudentDBContext context)
        {
            _Context = context;
        }

        // GET: api/StudentsData
        [HttpGet]
        public IActionResult GetStudents()
        {
            var student = _Context.StudentInfo.ToList();
            return Ok(student);
        }

        // GET: api/StudentsData/5
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _Context.StudentInfo.ToList();
            return Ok(student.FirstOrDefault(x => x.Id == id));
        }

        // POST: api/StudentsData
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]StudentRequest Temp)
        {
            StudentInfo student_one = new StudentInfo();
            student_one.FirstName = Temp.FirstName;
            student_one.LastName = Temp.LastName;
            student_one.Address = Temp.Address;
            student_one.City = Temp.City;
            _Context.StudentInfo.Add(student_one);
            _Context.SaveChanges();
            return Ok("Student added");
        }

        // PUT: api/StudentsData/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateByID(int id, [FromBody]StudentRequest Temp)
        {
            StudentInfo student_one = _Context.StudentInfo.FirstOrDefault(Student => Student.Id == id);
            student_one.FirstName = Temp.FirstName;
            student_one.LastName = Temp.LastName;
            student_one.Address = Temp.Address;
            student_one.City = Temp.City;
            _Context.StudentInfo.Update(student_one);
            _Context.SaveChanges();
            return Ok("upadted");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var student_one = _Context.StudentInfo.FirstOrDefault(Student => Student.Id == id);
            _Context.StudentInfo.Remove(student_one);
            _Context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
