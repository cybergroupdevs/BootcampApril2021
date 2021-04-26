using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        ProjectDBContext _context;

        public UserController(ProjectDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult AddUser([FromBody]UsersInfo user)
        {
            _context.UsersInfo.Add(user);
            _context.SaveChanges();
            return Ok("User Added successfully");
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetProject(String id)//parameter postman see ayega
        {
            var user = _context.UsersInfo.FirstOrDefault(users => users.InternId == id);
            return Ok(user);
        }

        [HttpGet]
        public ActionResult GetAllProjects()
        {
            var usersList = _context.UsersInfo.ToList();
            return Ok(usersList);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(string id)
        {
            var studentInfo = _context.UsersInfo.FirstOrDefault(student => student.InternId == id);
            _context.UsersInfo.Remove(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(string id, [FromBody] UsersInfo studentRequest)
        {
            UsersInfo studentInfo = _context.UsersInfo.FirstOrDefault(student => student.InternId == id);
            studentInfo.FullName = studentRequest.FullName;
            studentInfo.InternId = studentRequest.InternId;
            studentInfo.UserName = studentRequest.UserName;
            studentInfo.Projects = studentRequest.Projects;
            studentInfo.TechStack = studentRequest.TechStack;

            _context.UsersInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
    }
}