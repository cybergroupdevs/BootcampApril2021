using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentCrud.Controllers
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
        public ActionResult<List<StudentInfo>> GetAll()
        {

            return _context.StudentInfo.ToList();
        }

        // GET: api/StudentData/5
        [HttpGet("{id}")]
        public ActionResult<StudentInfo> GetById(int id)
        {
            StudentInfo s = _context.StudentInfo.FirstOrDefault(x => x.Id == id);
            return s;
        }

        // POST: api/StudentData
        [HttpPost]
        public ActionResult<StudentInfo> PostStudent([FromBody] StudentRequest student)
        {
            StudentInfo s = new StudentInfo();
                s.FirstName = student.FirstName;
                s.LastName = student.LastName;
                s.Address = student.City;

                s.City = student.City;
               _context.StudentInfo.Add(s);
               _context.SaveChanges();
            return s;
        }

        // PUT: api/StudentData/5
        [HttpPut("{id}")]
        public ActionResult<StudentInfo> UpdateStudebtById(int id, [FromBody] StudentRequest student)
        {
            StudentInfo s = _context.StudentInfo.FirstOrDefault(x => x.Id == id);
            s.Address = student.Address;
            s.FirstName = student.FirstName;
            s.LastName = student.LastName;
            s.City = student.City;

            _context.SaveChanges();
            return s;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string DeleteStudent(int id)
        {
            StudentInfo s = _context.StudentInfo.FirstOrDefault(x => x.Id == id);
            _context.Remove(s);
            _context.SaveChanges();
            return "Deleted Student";
        }
    }
}
