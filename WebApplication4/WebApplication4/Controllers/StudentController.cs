using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/student/5
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Student> Get(int id)
        {
            StreamReader r = new StreamReader(@"C:\Users\vipul.sinha\source\repos\WebApplication4\WebApplication4\Resources\student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items.Where(x => x.UserId == id).FirstOrDefault();
        }

        // GET: api/student/getall
        [HttpGet]
        [Route("/api/Student/GetAll")]
        public ActionResult<List<Student>> GetAll()
        {
            StreamReader r = new StreamReader(@"C:\Users\vipul.sinha\source\repos\WebApplication4\WebApplication4\Resources\student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items;
        }
        

        //POST: api/student
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            var file = @"C:\Users\vipul.sinha\source\repos\WebApplication4\WebApplication4\Resources\student.json";
            var json = System.IO.File.ReadAllText(file);
            var studentList = JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();

            studentList.Add(student);
            json = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(file, json);
        }

        // PUT api/student/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student student)
        {
            var filePath = @"C:\Users\vipul.sinha\source\repos\WebApplication4\WebApplication4\Resources\student.json";
            var jsonData = System.IO.File.ReadAllText(filePath);
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();

            for (int i = 0; i < studentList.Capacity; i++)
            {
                if (studentList[i].UserId == id)
                {
                    studentList[i].UserId = student.UserId;
                    studentList[i].FirstName = student.FirstName;
                    studentList[i].LastName = student.LastName;
                    break;
                }
            }
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }

        // DELETE: api/student/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var filePath = @"C:\Users\vipul.sinha\source\repos\WebApplication4\WebApplication4\Resources\student.json";
            var jsonData = System.IO.File.ReadAllText(filePath);
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();

            for (int i = 0; i < studentList.Capacity; i++)
            {
                if (studentList[i].UserId == id)
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