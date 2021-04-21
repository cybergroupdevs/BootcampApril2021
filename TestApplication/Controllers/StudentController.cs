using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        // GET: api/Student
        [HttpGet]
        public string testAction()
        {
            StreamReader r = new StreamReader(@"C:\Users\bhavana.nagpal\source\repos\TestApplication\TestApplication\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items.Where(x => x.id == 1).FirstOrDefault().name;
        }
        [Route("/Student/{id}")]
        [HttpGet("{id}")]
        public ActionResult<Student> getStudentById(int id)
        {
            StreamReader r = new StreamReader(@"C:\Users\bhavana.nagpal\source\repos\TestApplication\TestApplication\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items.Where(x => x.id == id).FirstOrDefault();
        }
        [HttpGet]
        [Route("/api/Student/GetAllStudents")]
        public List<Student> GetAll()
        {
            StreamReader r = new StreamReader(@"C:\Users\bhavana.nagpal\source\repos\TestApplication\TestApplication\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items;
        }


        // POST: api/Student
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            var filePath = @"C:\Users\bhavana.nagpal\source\repos\TestApplication\TestApplication\Resources\Student.json";
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
        }

        // DELETE: api/ApiWithActions/5

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var filePath = @"C:\Users\bhavana.nagpal\source\repos\TestApplication\TestApplication\Resources\Student.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();

            for (int i = 0; i < studentList.Capacity; i++)
            {
                if (studentList[i].id == id)
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

      