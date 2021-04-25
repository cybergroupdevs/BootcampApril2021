using assign.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>
        [HttpGet]
        [Route("/api/StudentClass/GetAllStudents")]
        public ActionResult<List<StudentClass>> GetAllStudents(int id)
        {
            StreamReader r = new StreamReader(@"C:\Users\shweta\source\repos\assign\assign\Resources\StudentData.json");
            string json = r.ReadToEnd();
            List<StudentClass> items = JsonConvert.DeserializeObject<List<StudentClass>>(json);
            return items;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}", Name="Get")]
        public ActionResult<StudentClass> GetStudentById(int id)
        {
            StreamReader r = new StreamReader(@"C:\Users\shweta\source\repos\assign\assign\assign.csproj");
            string json = r.ReadToEnd();
            List<StudentClass> items = JsonConvert.DeserializeObject<List<StudentClass>>(json);
            var ans = items.Where(x => x.Id == id).FirstOrDefault();
            return ans;
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] StudentClass student)
        {
            var filePath = @"C:\Users\shweta\source\repos\assign\assign\Resources\StudentData.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<StudentClass>>(jsonData)
                                  ?? new List<StudentClass>();

            studentList.Add(student);
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentClass student)
        {
            var filePath = @"C:\Users\shweta\source\repos\assign\assign\Resources\StudentData.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<StudentClass>>(jsonData)
                                  ?? new List<StudentClass>();

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

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var filePath = @"C:\Users\shweta\source\repos\assign\assign\Resources\StudentData.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<StudentClass>>(jsonData)
                                  ?? new List<StudentClass>();

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
