using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT_COLLEGE.Models;

namespace PROJECT_COLLEGE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class USER_INFOController : ControllerBase
    {
        // GET: api/USER_INFO
        CollegedbContext _context;


        public USER_INFOController(CollegedbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var studentList = _context.UserTable.ToList();
            return Ok(studentList);
        }
        [HttpPost]
        public ActionResult AddUser([FromBody] UserTable user)
        {
            _context.UserTable.Add(user);
            _context.SaveChanges();
            return Ok("User Details Added successfully");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userInfo = _context.UserTable.FirstOrDefault(user => user.UserId == id);
            _context.UserTable.Remove(userInfo);
            _context.SaveChanges();
            return Ok(userInfo);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] UserTable userRequest)
        {
            UserTable userInfo = _context.UserTable.FirstOrDefault(user => user.UserId == id);
            userInfo.UserName = userRequest.UserName;
            userInfo.Password = userRequest.Password;

            _context.UserTable.Update(userInfo);
            _context.SaveChanges();
            return Ok(userInfo);
        }
    }
}