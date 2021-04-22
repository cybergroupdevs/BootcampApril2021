using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test2.Models;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersDataController : ControllerBase
    {

        UsersDBContext _context;
        public UsersDataController(UsersDBContext context)
        {
            _context = context;
        }
        // GET: api/UsersData
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var userslist = _context.UsersInfo.ToList();
            return Ok(userslist);
        }

        // GET: api/UsersData/5
        [HttpGet("{id}")]
        public ActionResult GetUserById(int id)
        {
            var user = _context.UsersInfo.Where(x => x.Id == id);
            return Ok(user);
        }

        // POST: api/UsersData
        [HttpPost]
        public ActionResult Post([FromBody] UsersInfo user)
        {
            _context.UsersInfo.Add(user);
            _context.SaveChanges();
            return Ok("User added");
        }

        // PUT: api/UsersData/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UsersInfo usersRequest)
        {
            UsersInfo usersInfo = _context.UsersInfo.FirstOrDefault(user => user.Id == id);
            usersInfo.FirstName = usersRequest.FirstName;
            usersInfo.LastName = usersRequest.LastName;
            usersInfo.Age = usersRequest.Age;
            usersInfo.Address = usersRequest.Address;
           
            _context.UsersInfo.Update(usersInfo);
            _context.SaveChanges();
            return Ok(usersInfo);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var userdel = _context.UsersInfo.FirstOrDefault(user => user.Id == id);
            _context.UsersInfo.Remove(userdel);
            _context.SaveChanges();
            return Ok("User deleted");
        }
    }
}
