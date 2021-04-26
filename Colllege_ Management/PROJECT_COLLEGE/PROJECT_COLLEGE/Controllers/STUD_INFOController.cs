using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT_COLLEGE.Models;

namespace PROJECT_COLLEGE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class STUD_INFOController : ControllerBase
    {
        // GET: api/STUD_INFO
        CollegedbContext _context;


        public STUD_INFOController(CollegedbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var studentList = _context.StudentTable.ToList();
            return Ok(studentList);
        }
        [HttpPost]
        public ActionResult AddUser([FromBody] StudentTable user)
        {
            _context.StudentTable.Add(user);
            _context.SaveChanges();
            return Ok("Student Details Added successfully");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var studentInfo = _context.StudentTable.FirstOrDefault(student => student.StdId == id);
            _context.StudentTable.Remove(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] StudentTable studentRequest)
        {
            StudentTable studentInfo = _context.StudentTable.FirstOrDefault(student => student.StdId == id);
            studentInfo.StdName = studentRequest.StdName;
            studentInfo.StdPhone= studentRequest.StdPhone;
            studentInfo.StdDob = studentRequest.StdDob;
            studentInfo.StdFees = studentRequest.StdFees;
            studentInfo.StdGender = studentRequest.StdGender;
            studentInfo.StdDep = studentRequest.StdDep;

            _context.StudentTable.Update(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }

    }
}
