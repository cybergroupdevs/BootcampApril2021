using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Models;

namespace User.Controllers
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
        public ActionResult GetAllUsers()
        {
            var list = _context.UserInfo.ToList();
            return Ok(list);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult GetUserById(int id)
        {
            var user = _context.UserInfo.Where(x => x.Id == id);
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public ActionResult AddUser([FromBody]UserInfo user)
        {
            _context.UserInfo.Add(user);
            _context.SaveChanges();
            return Ok("User Added");

        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] UserInfo updateRequest)
        {
            UserInfo userInfo = _context.UserInfo.FirstOrDefault(user => user.Id == id);
            userInfo.FirstName = updateRequest.FirstName;
            userInfo.LastName = updateRequest.LastName;
            userInfo.Age = updateRequest.Age;
            userInfo.Address = updateRequest.Address;
            _context.UserInfo.Update(userInfo);
            _context.SaveChanges();
            return Ok(userInfo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            UserInfo userInfo = _context.UserInfo.FirstOrDefault(user => user.Id == id);
            _context.UserInfo.Remove(userInfo);
            _context.SaveChanges();
            return Ok(userInfo);
        }
    }
}
