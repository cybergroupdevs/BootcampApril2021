using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.DbModels;
using Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentDBContext _context;
       
       

        public StudentController(StudentDBContext context)
        {
            _context = context;
        }


            // GET: api/User
            [HttpGet]
            public ActionResult GetAllUsers()
            {
                var StudentList = _context.StudentInfo.ToList();
                return Ok(StudentList);
            }

            // GET: api/User/5
            [HttpGet("{id}", Name = "Get")]
            public ActionResult GetUserById(int id)
            {
            StudentInfo user = _context.StudentInfo.FirstOrDefault(student => student.Id == id);
                return Ok(user);
            }

            // POST: api/User
            [HttpPost]
            public ActionResult AddStudent([FromBody] Student abc)
            {
            StudentInfo user = new StudentInfo();
             user.FirstName = abc.FirstName;
            user.LastName = abc.LastName;
            user.Address = abc.Address;
            user.City = abc.City;
            _context.StudentInfo.Add(user);
                _context.SaveChanges();
                return Ok("Student Added successfully");
            }

            // PUT: api/User/5
            [HttpPut("{id}")]
            public ActionResult UpdateStudent(int id, [FromBody] Student abc)
            {
                StudentInfo user = _context.StudentInfo.FirstOrDefault(x => x.Id == id);
                user.FirstName = abc.FirstName;
                user.LastName = abc.LastName;
               
                _context.SaveChanges();
                return Ok("Updated");
            }

            // DELETE: api/ApiWithActions/5
            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                StudentInfo user = _context.StudentInfo.FirstOrDefault(x => x.Id == id);
                _context.StudentInfo.Remove(user);
                _context.SaveChanges();
                return Ok("Deleted");
            }
        }
    }

        

