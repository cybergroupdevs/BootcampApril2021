using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment1.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDataController : ControllerBase
    {
        StudentDBContext _context;

        public StudentDataController(StudentDBContext context) {
            _context = context;

        }
        [HttpGet]
        public ActionResult GetStudents()
        {
            var studentList = _context.StudentInfo.ToList();
            return Ok(studentList);
        }
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            var student = _context.StudentInfo.ToList();
            return Ok(student.FirstOrDefault(st => st.Id == id));
        }
        // POST: api/StudentData
        [HttpPost]
        public ActionResult AddStudent([FromBody]StudentRequest student)
        {
            StudentInfo st = new StudentInfo();
            st.FirstName = student.FirstName;
            st.LastName = student.LastName;
            st.Address = student.Address;
            st.City = student.City;


            _context.StudentInfo.Add(st);
            _context.SaveChanges();

            return Ok("Changes saved successfully");

        }
        // PUT: api/StudentData/5
       [HttpPut("{id}")]
        public ActionResult UpdateStudentList(int id, [FromBody] StudentRequest studentRequest)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            studentInfo.FirstName = studentRequest.FirstName;
            studentInfo.LastName = studentRequest.LastName;
            studentInfo.Address = studentRequest.Address;
            studentInfo.City = studentRequest.City;

            _context.StudentInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);


        }
        [HttpDelete("{id}")]
        public ActionResult DeleteStudentById(int id)
        {
            StudentInfo studentInfo = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
            _context.StudentInfo.Remove(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }

        

        // GET: api/StudentData/5
        

       

        
        

        
    }
}
