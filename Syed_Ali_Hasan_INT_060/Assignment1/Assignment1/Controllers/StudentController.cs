using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;
using Assignment1.Models;
using Assignment1.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assignment1.Controllers
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
        public ActionResult GetStudents()
        {
            var studentList = _context.StudentInfo.ToList();
            return Ok(studentList);
        }

        //// GET: api/Student/5
        //[HttpGet("{id}", Name = "Get")]
        //public ActionResult<Student> GetStudentById(int id)
        //{
        //    StreamReader r = new StreamReader(Global.getFile());
        //    string json = r.ReadToEnd();
        //    List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
        //    var ans = items.Where(x => x.Id == id).FirstOrDefault();
        //    return ans;
        //}

        //// GET: api/Student/5
        //[HttpGet]
        //[Route("/api/Student/GetAllStudents")]
        //public ActionResult<List<Student>> GetAllStudents()
        //{
        //    StreamReader r = new StreamReader(Global.getFile());
        //    string json = r.ReadToEnd();
        //    List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
        //    return items;
        //}

        //POST: api/Student
        [HttpPost]
        public ActionResult AddStudent([FromBody]StudentInfo student)
        {
            _context.StudentInfo.Add(student);
            _context.SaveChanges();
            return Ok("Student Added successfully");
        }

        // PUT api/Student/5
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

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void DeleteStudentById(int id)
        //{
        //    // Read existing json data
        //    var jsonData = System.IO.File.ReadAllText(Global.getFile());
        //    // De-serialize to object or create new list
        //    var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
        //                          ?? new List<Student>();

        //    for (int i = 0; i < studentList.Capacity; i++)
        //    {
        //        if (studentList[i].Id == id)
        //        {
        //            studentList.RemoveAt(i);
        //            break;
        //        }
        //    }
        //    jsonData = JsonConvert.SerializeObject(studentList);
        //    System.IO.File.WriteAllText(Global.getFile(), jsonData);
        //}
    }
}
