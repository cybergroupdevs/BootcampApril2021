using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UserDemo.DbModels;
using UserDemo.Models;

namespace UserDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        StudentDBContext _context;

        

        public UserController(StudentDBContext context)
        {
            _context = context;
            
        }


        

      
        // GET: api/User
        [HttpGet]
        [Authorize]
        public ActionResult Get()
        {
            var user = _context.StudentInfo.ToList();
            return Ok(user);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public StudentInfo GetUserByID(int id)
        {
            var user = _context.StudentInfo.FirstOrDefault(studentInfo => studentInfo.Id == id);
            return user;
        }

        // POST: api/User

        [HttpPost]
        public ActionResult Add([FromBody] UserRequest userRequest)
        {
            StudentInfo studentInfo = new StudentInfo()
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Age = userRequest.Age,
                Address = userRequest.Address
            };
            _context.StudentInfo.Add(studentInfo);
            _context.SaveChanges();
            return Ok("User Added");
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] UserRequest userRequest)
        {
            StudentInfo studentInfo = GetUserByID(id);
            studentInfo.FirstName = userRequest.FirstName;
            studentInfo.LastName = userRequest.LastName;
            studentInfo.Address = userRequest.Address;
            studentInfo.Age = userRequest.Age;
            _context.SaveChanges();
            return Ok("student updated!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var demo = GetUserByID(id);
            _context.StudentInfo.Remove(demo);
            _context.SaveChanges();
            return Ok(demo);
        }
    }
}
