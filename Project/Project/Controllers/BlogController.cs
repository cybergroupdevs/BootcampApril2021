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
    [Authorize]
    public class BlogController : ControllerBase
    {
        ProjectDBContext _context;

        public BlogController(ProjectDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult AddUser([FromBody]BlogInfo blog)
        {
            _context.BlogInfo.Add(blog);
            _context.SaveChanges();
            return Ok("Blog Added successfully");
        }

        [HttpGet]
        [Route("{username}")]
        public ActionResult GetBlog(string username)//parameter postman see ayega
        {
            var blog = _context.BlogInfo.Where(stud => stud.Username == username);
            return Ok(blog);
        }

        [HttpGet]
        public ActionResult GetAllBlogs()
        {
            var blogsList = _context.BlogInfo.ToList();
            return Ok(blogsList);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var studentInfo = _context.BlogInfo.FirstOrDefault(student => student.BlogId == id);
            _context.BlogInfo.Remove(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] BlogInfo studentRequest)
        {
            BlogInfo studentInfo = _context.BlogInfo.FirstOrDefault(student => student.BlogId == id);
            studentInfo.Head = studentRequest.Head;
            studentInfo.Body = studentRequest.Body;
            studentInfo.Username = studentRequest.Username;
            _context.BlogInfo.Update(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
    }
}