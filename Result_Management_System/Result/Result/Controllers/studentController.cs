using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Result.Models;

namespace Result.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentController : ControllerBase
    {
        StudDBContext _context;
        public studentController(StudDBContext context)
        {
            _context = context;
        }
        // GET: api/student
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var list = _context.StudInfo.ToList();
            return Ok(list);
        }

        // GET: api/student/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult GetUserById(int id)
        {
            var user = _context.StudInfo.Where(x => x.Id == id);
            return Ok(user);
        }

        // POST: api/student
        [HttpPost]
        public ActionResult AddUser([FromBody]StudInfo stud)
        {
            _context.StudInfo.Add(stud);
            _context.SaveChanges();
            return Ok("Student Added");

        }


        // PUT: api/student/5
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] StudInfo updateRequest)
        {
            StudInfo studInfo = _context.StudInfo.FirstOrDefault(user => user.Id == id);
            studInfo.Name = updateRequest.Name;
            studInfo.English = updateRequest.English;
            studInfo.Hindi = updateRequest.Hindi;
            studInfo.Spanish= updateRequest.Spanish;
            studInfo.Mathematics = updateRequest.Mathematics;
            studInfo.Science = updateRequest.Science;
            _context.StudInfo.Update(studInfo);
            _context.SaveChanges();
            return Ok(studInfo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            StudInfo studInfo = _context.StudInfo.FirstOrDefault(stud => stud.Id == id);
            _context.StudInfo.Remove(studInfo);
            _context.SaveChanges();
            return Ok(studInfo);
        }
    }
}
