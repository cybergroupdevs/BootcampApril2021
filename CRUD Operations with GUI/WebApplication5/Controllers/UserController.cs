using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
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

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            UserInfo userInfo = _context.UserInfo.FirstOrDefault(user => user.Id == id);
            return Ok(userInfo);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] UserInfo UserRequest)
        {
            UserInfo userInfo = _context.UserInfo.FirstOrDefault(user => user.Id == id);
            userInfo.FirstName = UserRequest.FirstName;
            userInfo.LastName = UserRequest.LastName;
            userInfo.Age = UserRequest.Age;
            userInfo.Address = UserRequest.Address;
            _context.UserInfo.Update(userInfo);
            _context.SaveChanges();
            return Ok(userInfo);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var UserInfo = _context.UserInfo.FirstOrDefault(user => user.Id == id);
            _context.UserInfo.Remove(UserInfo);
            _context.SaveChanges();
            return Ok(UserInfo);
        }
    }
}