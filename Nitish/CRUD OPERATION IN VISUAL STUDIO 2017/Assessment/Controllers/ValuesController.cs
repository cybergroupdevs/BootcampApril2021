using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Assessment.Models;

namespace Assessment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string testAction()
        {
            return "Test successful";
        }

        // GET api/values/  
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Student> GetStudentById(int id)
        {
            StreamReader r = new StreamReader(@"c:\users\nitish.sharma\source\repos\Assessment\Assessment\Resources\Students.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            var ans = items.Where(x => x.Id == 1).FirstOrDefault();
            return ans;
        }


        // GET api/values/(id)
        [HttpGet]
        [Route("/api/Values/GetAllStudents")]
        public ActionResult<List<Student>> GetAllStudents()
        {
            StreamReader r = new StreamReader(@"c:\users\nitish.sharma\source\repos\Assessment\Assessment\Resources\Students.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items;
        }


        // POST api/values/names
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            var filePath = @"c:\users\nitish.sharma\source\repos\Assessment\Assessment\Resources\Students.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();

            studentList.Add(student);
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }

        // PUT api/Student/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student student)
        {
            var filePath = @"c:\users\nitish.sharma\source\repos\Assessment\Assessment\Resources\Students.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData) ?? new List<Student>();
            
            for (int i = 0; i < studentList.Capacity; i++)
            {
                if (studentList[i].Id == Id)
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
            var filePath = @"c:\users\nitish.sharma\source\repos\Assessment\Assessment\Resources\Students.json";
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

    class JavaScriptSerializer
    {
        public JavaScriptSerializer()
        {
        }
    }
}
