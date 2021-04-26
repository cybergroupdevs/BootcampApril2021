using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using assign.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;



namespace assign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public String GetFilePAth()
        {
            return @"C:\Users\aditya.sharma\source\repos\assign\assign\Resources\Student.txt";
        }
        // Get: api/Student
        [HttpGet]

        public ActionResult<String> TestCase()
        {
            return "Tese case working";
        }

        // GET: api/Student/GetAllStudent
        [HttpGet("{GetAllStudent}")]
        public ActionResult<List<Student>> GetAllStudent()

        {
            StreamReader r = new StreamReader(@"C:\Users\aditya.sharma\source\repos\assign\assign\Resources\Student.json");

            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);
            
            return items;
        }

     
      
        // GET: api/Student/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Student> GetStudentById(int id)
        {
            StreamReader r = new StreamReader(@"C:\Users\aditya.sharma\source\repos\assign\assign\Resources\Student.json");

            string json = r.ReadToEnd();
            List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);

            return items.Where(x => x.Id == id).FirstOrDefault();
        }

       

        //POST: api/Student
        [HttpPost]
        public void AddNewStudent([FromBody]Student student)
        {
            var filePath = GetFilePAth();
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            List<Student> studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData); 
            studentList.Add(student);
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(filePath, jsonData);
        }

        // PUT api/Student/5
        [HttpPut("{id}")]
        public void UpdateStudentById(int id, [FromBody] Student student)
        {
            var filePath = GetFilePAth();
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            List<Student> studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData);
                                  

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
        public void DeleteStudentByID(int id)
        {
            var filePath = GetFilePAth();
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            List<Student> studentList = JsonConvert.DeserializeObject<List<Student>>(jsonData);
                                 

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
