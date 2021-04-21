using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using assign.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace assign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private Student student;


        // GET: api/Student
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Student
        [HttpGet]

        public string testaction()
        {
            return "This is test";
        }

        // GET: api/Student/5
        [HttpGet("{Id}",Name ="Get")]
        public ActionResult<Student> GetStudentById(int id)
        {
            StreamReader r = new StreamReader(@"C:\Users\srishti.sharma\source\repos\assign\assign\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            var ans = items.Where(x => x.Id == id).FirstOrDefault();
            return ans;
        }

        // GET: api/Student/5
        [HttpGet]
        [Route("/api/Student/GetAllStudents")]

        public ActionResult<List<Student>> GetAll()
        {
            StreamReader r = new StreamReader(@"C:\Users\srishti.sharma\source\repos\assign\assign\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            var ans = items.ToList();
            return ans;
        }

        // POST: api/Student
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var filePath = @"C:\Users\srishti.sharma\source\repos\assign\assign\Resources\Student.json";
            //Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            //De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                   ?? new List<Student>();

            studentList.Add(student);
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

            var filePath = @"C:\Users\srishti.sharma\source\repos\assign\assign\Resources\Student.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
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
            System.IO.File.WriteAllText(filePath, jsonData);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var filePath = (@"C:\Users\srishti.sharma\source\repos\assign\assign\Resources\Student.json");
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
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
            System.IO.File.WriteAllText(filePath, jsonData);

        }
    }
}
