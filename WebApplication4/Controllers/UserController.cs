
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        UserDBContext _context;


        public UserController(UserDBContext context)
        {
            _context = context;
        }


        [HttpPost]
        public ActionResult AddUser([FromBody] UserInfo user)
        {
            _context.UserInfo.Add(user);
            _context.SaveChanges();
            return Ok("User Details Added successfully");
        }


        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var studentList = _context.UserInfo.ToList();
            return Ok(studentList);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var studentInfo = _context.UserInfo.FirstOrDefault(student => student.Id == id);
            _context.UserInfo.Remove(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] UserInfo studentRequest)
        {
            UserInfo studentInfo = _context.UserInfo.FirstOrDefault(student => student.Id == id);
            studentInfo.FirstName = studentRequest.FirstName;
            studentInfo.LastName = studentRequest.LastName;
            _context.UserInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }

    }

}