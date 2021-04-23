using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using testProject.Models;
//using Newtonsoft.Json.Linq;

namespace testProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {

        //[HttpGet]
        //public ActionResult<test> TestCall()
        //{
        //   StreamReader r = new StreamReader(@"C:\Users\ahana.drall\source\repos\testProject\testProject\resources\test.json");
        //  string json = r.ReadToEnd();
        // List<test> items = JsonConvert.DeserializeObject<List<test>>(json);

        //  return items.Where(x => x.id == 1).FirstOrDefault();
        // }

        [HttpGet("{id}")]
        public test Getid(int id)
        {
            StreamReader r = new StreamReader(@"C:\Users\ahana.drall\source\repos\testProject\testProject\resources\test.json");
            string json = r.ReadToEnd();
            List<test> items = JsonConvert.DeserializeObject<List<test>>(json);

            return items.Where(x => x.id == id).FirstOrDefault();
        }
        [HttpGet]
        public List<test> GetAll()
        {
            StreamReader r = new StreamReader(@"C:\Users\ahana.drall\source\repos\testProject\testProject\resources\test.json");
            string json = r.ReadToEnd();
            List<test> items = JsonConvert.DeserializeObject<List<test>>(json);

            return items.ToList();
        }



        // GET: api/test
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //   return new string[] { "value1", "value2" };
        //}

        // GET: api/test/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //   return "ahana";
        //}

        // POST: api/test
        // [HttpPost]
        //public void Post([FromBody] string value)
        // {
        // }

        // PUT: api/test/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        // POST: api/test
        [HttpPost]
        public void Post([FromBody]test student)
        {
            var filePath = @"C:\Users\ahana.drall\source\repos\testProject\testProject\resources\test.json";
            //Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            //De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<test>>(jsonData)
                   ?? new List<test>();

            studentList.Add(student);
            jsonData = JsonConvert.SerializeObject(studentList);
            System.IO.File.WriteAllText(filePath, jsonData);

        }





        // DELETE: api/ApiWithActions/5

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var filePath = @"C:\Users\ahana.drall\source\repos\testProject\testProject\resources\test.json";
            // Read existing json data
            var jsonData = System.IO.File.ReadAllText(filePath);
            // De-serialize to object or create new list
            var studentList = JsonConvert.DeserializeObject<List<test>>(jsonData)
                                  ?? new List<test>();

            for (int i = 0; i < studentList.Capacity; i++)
            {
                if (studentList[i].id == id)
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
    

    


