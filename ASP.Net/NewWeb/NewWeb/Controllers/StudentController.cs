using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;
using NewWeb.Models;

namespace NewWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/Student
        [HttpGet]
        public string TestAction()
        {
            return "this is a test get request";
        }

        // GET: api/Student/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Student> GetById(int id)
        {
            StreamReader File = new StreamReader(@"c:\users\vikas.upadhayay\source\repos\NewWeb\NewWeb\resources\Students.json");
            string json = File.ReadToEnd();
            List<Student> Items = JsonConvert.DeserializeObject<List<Student>>(json);
            File.Close();
            return Items.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Student
        [HttpPost]
        public void Post([FromBody]Student value)
        {
            var Temp_Json = new Student();
            Temp_Json.Id = value.Id;
            Temp_Json.Name = value.Name;
            Temp_Json.Department = value.Department;
            Temp_Json.Age = value.Age;
            Temp_Json.College = value.College;

            StreamReader File = new StreamReader(@"c:\users\vikas.upadhayay\source\repos\NewWeb\NewWeb\resources\Students.json");
            string Json = File.ReadToEnd();
            List<Student> Items = JsonConvert.DeserializeObject<List<Student>>(Json);
            Items.Add(Temp_Json);

            File.Close();

            string WriteJson = JsonConvert.SerializeObject(Items.ToArray());
            StreamWriter WriteFile = new StreamWriter(@"c:\users\vikas.upadhayay\source\repos\NewWeb\NewWeb\resources\Students.json");
            //write file logic here
            WriteFile.Write(WriteJson);
            WriteFile.Close();
        }


        // PUT: api/Student/5
        [HttpPut("{id}")]
        public ActionResult<string> PutById(int id, [FromBody]Student value)
        {
            StreamReader File = new StreamReader(@"c:\users\vikas.upadhayay\source\repos\NewWeb\NewWeb\resources\Students.json");
            string json = File.ReadToEnd();
            List<Student> Items = JsonConvert.DeserializeObject<List<Student>>(json);

            for (int i = 0; i < Items.Capacity; i++)
            {
                if (Items[i].Id == id)
                {
                    Items[i].Id = value.Id;
                    Items[i].Name = value.Name;
                    Items[i].Department = value.Department;
                    Items[i].Age = value.Age;
                    Items[i].College = value.College;
                    break;
                }
            }
            File.Close();
            string WriteJson = JsonConvert.SerializeObject(Items.ToArray());
            StreamWriter WriteFile = new StreamWriter(@"c:\users\vikas.upadhayay\source\repos\NewWeb\NewWeb\resources\Students.json");
            WriteFile.Write(WriteJson);
            WriteFile.Close();
            return "Record Updated";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            StreamReader File = new StreamReader(@"c:\users\vikas.upadhayay\source\repos\NewWeb\NewWeb\resources\Students.json");
            string Json = File.ReadToEnd();
            List<Student> Items = JsonConvert.DeserializeObject<List<Student>>(Json);

            for (int i = 0; i < Items.Capacity; i++)
            {
                if (Items[i].Id == id)
                {
                    Items.RemoveAt(i);
                    break;
                }
            }

            File.Close();

            string WriteJson = JsonConvert.SerializeObject(Items.ToArray());
            StreamWriter WriteFile = new StreamWriter(@"c:\users\vikas.upadhayay\source\repos\NewWeb\NewWeb\resources\Students.json");
            WriteFile.Write(WriteJson);
            WriteFile.Close();
            return "Record Deleted";
        }
    }
}
