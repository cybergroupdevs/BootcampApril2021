using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assign.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Assign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/Student
        [HttpGet]
        
        public string Testcall()
        {
            StreamReader r = new StreamReader(@"C:\Users\anurag.sharma\source\repos\Assign\Assign\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items.Where(x => x.Id == 1).FirstOrDefault().Name;

        }

        [HttpGet("{Id}")]
        public ActionResult<Student> GetStudentById(int Id)
        {
            StreamReader r = new StreamReader(@"C:\Users\anurag.sharma\source\repos\Assign\Assign\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items.Where(x => x.Id == Id).FirstOrDefault();
        }

        [HttpGet]
        [Route("/api/Student/GetAllStudents")]
        public List<Student> GetAll()
        {
            StreamReader r = new StreamReader(@"C:\Users\anurag.sharma\source\repos\Assign\Assign\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items;
        }


        // POST: api/Student
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            var filePath = @"C:\Users\anurag.sharma\source\repos\Assign\Assign\Resources\Student.json";
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
            var filePath = @"C:\Users\anurag.sharma\source\repos\Assign\Assign\Resources\Student.json";
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
