using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{

  
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private Student student;

        public int Id { get; private set; }

        // GET: api/Student
        [HttpGet]
        public string testAction()
        {
          StreamReader r = new StreamReader(@"C:\Users\divyanshu.goyal\source\repos\WebApplication3\WebApplication3\Resources\Student.json");
           string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items.Where(x => x.Id==1).FirstOrDefault().Name;
        }
        //[HttpGet]
        //public ActionResult<Student> getElements(int id)
        //{
        //    StreamReader r = new StreamReader(@"C:\Users\divyanshu.goyal\source\repos\WebApplication3\WebApplication3\Resources\Student.json");
        //    string json = r.ReadToEnd();
        //    List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
        //    return items.Where(x => x.Id == id).FirstOrDefault();
        //}
        //public ActionResult Index()
        //{
        //    //get the Json filepath  
        //    string file = Server.MapPath("~/App_Data/output.json");
        //    //deserialize JSON from file  
        //    string Json = System.IO.File.ReadAllText(file);
        //    JavaScriptSerializer ser = new JavaScriptSerializer();
        //    var personlist = ser.Deserialize<List<Person>>(Json);
        //    return View(personlist);
        //}




        // GET: api/Student/5

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Student> GetStudentById(int id)
        {
            StreamReader r = new StreamReader(@"C:\Users\divyanshu.goyal\source\repos\WebApplication3\WebApplication3\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpGet("all")]
        public List<Student> GetAll()
        {
            StreamReader r = new StreamReader(@"C:\Users\divyanshu.goyal\source\repos\WebApplication3\WebApplication3\Resources\Student.json");
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            return items.ToList();

        }

        // POST: api/Student
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            var filePath = @"C:\Users\divyanshu.goyal\source\repos\WebApplication3\WebApplication3\Resources\Student.json";
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
            var filePath = @"E:\BootcampApril2021\Syed_Ali_Hasan_INT_060\Assignment1\Assignment1\Resource\Student.json";
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
            var filePath = @"C:\Users\divyanshu.goyal\source\repos\WebApplication3\WebApplication3\Resources\Student.json";
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
