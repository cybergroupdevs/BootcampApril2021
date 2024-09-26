using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using assignment1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace assignment1.Controllers
{
    public static class Global
    {
        public static string getPath()
        {
            return @"C:\Users\bhanuja.aggarwal\source\repos\assignment1\assignment1\resources\Student.json";
        }

    }
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public object Jsonconvert { get; private set; }
        public int Id { get; private set; }

      

        // GET: api/Student
       [HttpGet]
        public string testAction()
        {
            return "test action completed successfully";
            
        }

        // GET: api/Student/5
        [HttpGet("{Id}")]
        public Student GetById(int Id)
        {
            StreamReader r = new StreamReader(Global.getPath());
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            var res = items.Where(x => x.Id == Id).FirstOrDefault();
            return res;
        }
        


        [HttpGet]
        [Route("/api/Student/GetAll")]
        public List<Student> GetAll()
        {
            StreamReader r = new StreamReader(Global.getPath());
            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            var res = items.ToList();
            return res;
        }




        // POST: api/Student
        [HttpPost]
        public void Post([FromBody]Student Student)
        {
            var FilePath = @"C:\Users\bhanuja.aggarwal\source\repos\assignment1\assignment1\resources\Student.json";
            
            var jsonData = System.IO.File.ReadAllText(FilePath);
            // De-serialize to object or create new list
            var StudentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();


            StudentList.Add(Student);
            jsonData = JsonConvert.SerializeObject(StudentList);
            System.IO.File.WriteAllText(FilePath, jsonData);
        }


        // PUT: api/Student/4
        [HttpPut("{Id}")]
        public void Put(int Id, [FromBody] Student Student)
        {
            var filePath = Global.getPath();
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();


            for (int i = 0; i < studentList.Capacity; i++)
            {
                if (studentList[i].Id == Id)
                {
                    studentList[i].Id = Student.Id;
                    studentList[i].Name = Student.Name;
                    studentList[i].Department = Student.Department;
                    studentList[i].Age = Student.Age;
                    studentList[i].College = Student.College;
                    break;
                }
            }
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            var filePath = Global.getPath();
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData)
                                  ?? new List<Student>();


            for (int i = 0; i < studentList.Capacity; i++)
            {
                if (studentList[i].Id == Id)
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
