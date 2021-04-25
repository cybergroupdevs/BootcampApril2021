using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UserAssignment.Models;
using Microsoft.AspNetCore.Authorization;

namespace UserAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserDBContext _context;
        public UserController(UserDBContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        [Authorize]
        public ActionResult GetAllUsers()
        {
            var userList = _context.User.ToList();
            return Ok(userList);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult GetUserById(int id)
        {
            User user = _context.User.FirstOrDefault(student => student.Id == id);
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public ActionResult AddUser([FromBody] User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return Ok("User Added successfully");
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] User user)
        {
            User userInfo = _context.User.FirstOrDefault(student => student.Id == id);
            userInfo.Name = user.Name;
            userInfo.DateTime = user.DateTime;
            userInfo.Resolver = user.Resolver;
            userInfo.Solution = user.Solution;
            _context.User.Update(userInfo);
            _context.SaveChanges();
            return Ok(userInfo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            User userInfo = _context.User.FirstOrDefault(user => user.Id == id);
            _context.User.Remove(userInfo);
            _context.SaveChanges();
            return Ok(userInfo);
        }
    }
}
