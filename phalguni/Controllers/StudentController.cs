using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using Newtonsoft.Json;
using Elmah.ContentSyndication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>
        // GET api/<StudentController>/5
        [HttpGet("{id}", Name ="GET")]
        public ActionResult<Student> GetStudentsById(int id)
        {
            StreamReader r = new StreamReader(@"C:\Users\phalguni.dhamija\source\repos\WebApplication3\WebApplication3\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            var ans = items.Where(x => x.Id == id).FirstOrDefault();
            return ans;

        }
        [HttpGet]
        [Route("/api/Student/GetAllStudents")]
        public List<Student> GetAll(int id)
        {
            StreamReader r = new StreamReader(@"C:\Users\phalguni.dhamija\source\repos\WebApplication3\WebApplication3\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            var ItemsList = items.ToList();
            return ItemsList;

        }


        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            var filePath = @"C:\Users\phalguni.dhamija\source\repos\WebApplication3\WebApplication3\Resources\Student.json";
            var jsonData = System.IO.File.ReadAllText(filePath);
            var studentsList = JsonConvert.DeserializeObject<List<Student>>(jsonData) ?? new List<Student>();
            studentsList.Add(student);
            jsonData = JsonConvert.SerializeObject(studentsList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student student)
        {
            var filePath = @"C:\Users\phalguni.dhamija\source\repos\WebApplication3\WebApplication3\Resources\Student.json";
            var jsonData = System.IO.File.ReadAllText(filePath);
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData) ?? new List<Student>();
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
            var filePath = @"C:\Users\phalguni.dhamija\source\repos\WebApplication3\WebApplication3\Resources\Student.json";
            var jsonData = System.IO.File.ReadAllText(filePath);
            var studentsList = JsonConvert.DeserializeObject<List<Student>>(jsonData) ?? new List<Student>();
            for(int i=0;i<studentsList.Capacity;i++)
            {
                if(studentsList[i].Id == id)
                {
                    studentsList.RemoveAt(i);
                    break;
                }
            }
            jsonData = JsonConvert.SerializeObject(studentsList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }
    }
}
