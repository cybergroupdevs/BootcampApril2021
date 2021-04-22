﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAssignment.Models;

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
        public ActionResult GetAllUsers()
        {
            var userList = _context.User.ToList();
            return Ok(userList);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
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
            userInfo.FirstName = user.FirstName;
            userInfo.LastName = user.LastName;
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
