using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using test2.Models;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/Student
         /*[HttpGet]
         public ActionResult<String> TestAction()
         {
             StreamReader r = new StreamReader(@"C:\Users\mansha.madaan\source\repos\test2\test2\Resources\Student.json");
             string json = r.ReadToEnd();
             List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
             return items.Where(x => x.Id == 1).FirstOrDefault().Name;
         }*/

        // GET: api/Student/5
        [HttpGet]
        public List<Student> GetAll()
        {
            StreamReader r = new StreamReader(@"C:\Users\mansha.madaan\source\repos\test2\test2\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            var ans = items.ToList();
            return ans;
        }

        [HttpGet("{Id}")]
        public Student GetById(int Id)
        {
            StreamReader r = new StreamReader(@"C:\Users\mansha.madaan\source\repos\test2\test2\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            var ans = items.Where(x => x.Id == Id).FirstOrDefault();
            return ans;
        }

        // POST: api/Student
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            var filePath = @"C:\Users\mansha.madaan\source\repos\test2\test2\Resources\Student.json";
            //Read Existing Json data
            var jsonData = System.IO.File.ReadAllText(filePath);

            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                ?? new List<Student>();

            studentList.Add(student);

            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(filePath, jsonData);


        }

        // PUT: api/Student/5
        [HttpPut("{ id}")]

        public void Put(int id, [FromBody] Student student)
        {
            var filePath = @"C:\Users\mansha.madaan\source\repos\test2\test2\Resources\Student.json";
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
            var filePath = @"C:\Users\mansha.madaan\source\repos\test2\test2\Resources\Student.json";
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
