using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assignment1.Controllers
{
    public static class Global
    {
        public static string getFile()
        {
            return @"E:\BootcampApril2021\Syed_Ali_Hasan_INT_060\Assignment1\Assignment1\Resource\Student.json";
        }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/Student
        [HttpGet]
        public string testAction()
        {
            return "Test successful";
        }

        // GET: api/Student/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Student> GetStudentById(int id)
        {
            StreamReader r = new StreamReader(Global.getFile());
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            var ans = items.Where(x => x.Id == id).FirstOrDefault();
            return ans;
        }

        // GET: api/Student/5
        [HttpGet]
        [Route("/api/Student/GetAllStudents")]
        public ActionResult<List<Student>> GetAllStudents()
        {
            StreamReader r = new StreamReader(Global.getFile());
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items;
        }

        //POST: api/Student
        [HttpPost]
        public void AddStudentInfo([FromBody]Student student)
        {
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(Global.getFile());
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();

            studentList.Add(student);
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(Global.getFile(), jsonData);
        }

        // PUT api/Student/5
        [HttpPut("{id}")]
        public void UpdateStudentById(int id, [FromBody] Student student)
        {
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(Global.getFile());
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();

            for (int i = 0; i < studentList.Capacity; i++)
            {
                if (studentList[i].Id == id)
                {
                    studentList[i].Id = student.Id;
                    studentList[i].Name = student.Name;
                    studentList[i].Department = student.Department;
                    studentList[i].Age = student.Age;
                    studentList[i].College = student.College;
                    break;
                }
            }
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(Global.getFile(), jsonData);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteStudentById(int id)
        {
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(Global.getFile());
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();

            for (int i = 0; i < studentList.Capacity; i++)
            {
                if (studentList[i].Id == id)
                {
                    studentList.RemoveAt(i);
                    break;
                }
            }
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(Global.getFile(), jsonData);
        }
    }
}
