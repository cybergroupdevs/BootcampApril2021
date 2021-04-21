using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AssignmentCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AssignmentCrud.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/Student
        [HttpGet("test")]
        public ActionResult<String> TestRequest()
        {
            //StreamReader r = new StreamReader(@"c:\users\himanshu\source\repos\AssignmentCrud\AssignmentCrud\Resources\Student.json");

            // string json = r.ReadToEnd();
            //List<Student> items = JsonConvert.DeserializeObject<List<Student>>(json);

            return "this is test route"; 
               // items.Where(x=> x.Id == 1 ).FirstOrDefault();
        }

     
         

    // GET: api/Student/5
        [HttpGet("{id}")]
        public ActionResult<Student>GetById(int id)
        {
            StreamReader File = new StreamReader(@"c:\users\himanshu\source\repos\AssignmentCrud\AssignmentCrud\Resources\Student.json");

            string Json = File.ReadToEnd();
            List<Student> Items = JsonConvert.DeserializeObject<List<Student>>(Json);

            File.Close();

            return Items.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {
            StreamReader File = new StreamReader(@"c:\users\himanshu\source\repos\AssignmentCrud\AssignmentCrud\Resources\Student.json");

            string Json = File.ReadToEnd();
            List<Student> Items = JsonConvert.DeserializeObject<List<Student>>(Json);

            File.Close();
            return Items;
        }
        // POST: api/Student
        [HttpPost]
        public ActionResult<Student>CreateStudent([FromBody] Student Value)
        {
         
            Student s = new Student();
            s.Id = Value.Id;
            s.Name = Value.Name;
            s.Age = Value.Age;
            s.Department = Value.Department;
            s.College = Value.College;
            StreamReader File = new StreamReader(@"c:\users\himanshu\source\repos\AssignmentCrud\AssignmentCrud\Resources\Student.json");
            string Json = File.ReadToEnd();
            List<Student> Items = JsonConvert.DeserializeObject<List<Student>>(Json);

            Items.Add(s);
            File.Close();

            string WriteJson = JsonConvert.SerializeObject(Items.ToArray());
            StreamWriter WriteFile = new StreamWriter(@"c:\users\himanshu\source\repos\AssignmentCrud\AssignmentCrud\Resources\Student.json");
            //write file logic here
            WriteFile.Write(WriteJson);
            WriteFile.Close();
            return s;

        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public ActionResult<string> UpdateStudent(int Id, [FromBody] Student Value)
        {
            Student s = new Student();
            s.Id = Id;
            s.Name = Value.Name;
            s.Age = Value.Age;
            s.Department = Value.Department;
            s.College = Value.College;
            StreamReader File = new StreamReader(@"c:\users\himanshu\source\repos\AssignmentCrud\AssignmentCrud\Resources\Student.json");
            string Json = File.ReadToEnd();
            List<Student> Items = JsonConvert.DeserializeObject<List<Student>>(Json);
            //Items.Where(x => x.Id == 1).FirstOrDefault()

            for(int i=0;i<Items.Capacity;i++){
                if (Items[i].Id == Id){
                    Items[i] = s;
                    break;
                }
            }

            File.Close();

            string WriteJson = JsonConvert.SerializeObject(Items.ToArray());
            StreamWriter WriteFile = new StreamWriter(@"c:\users\himanshu\source\repos\AssignmentCrud\AssignmentCrud\Resources\Student.json");
            //write file logic here
            WriteFile.Write(WriteJson);
            WriteFile.Close();

            return "Data Updated";

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteStudent(int Id)
        {

            StreamReader File = new StreamReader(@"c:\users\himanshu\source\repos\AssignmentCrud\AssignmentCrud\Resources\Student.json");
            string Json = File.ReadToEnd();
            List<Student> Items = JsonConvert.DeserializeObject<List<Student>>(Json);
            //Items.Where(x => x.Id == 1).FirstOrDefault()

            for (int i = 0; i < Items.Capacity; i++)
            {
                if (Items[i].Id == Id)
                {
                    Items.RemoveAt(i);
                    break;
                }
            }

            File.Close();

            string WriteJson = JsonConvert.SerializeObject(Items.ToArray());
            StreamWriter WriteFile = new StreamWriter(@"c:\users\himanshu\source\repos\AssignmentCrud\AssignmentCrud\Resources\Student.json");
            //write file logic here
            WriteFile.Write(WriteJson);
            WriteFile.Close();
            return "Record Deleted";
        }
    }
}
 
