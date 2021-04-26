using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserDBController : ControllerBase
    {
        UsersDataContext _Context;


        public UserDBController(UsersDataContext context)
        {
            _Context = context;
        }

        // GET: api/UserDB
        [HttpGet]
        public ActionResult GetAllUser()
        {
            var userList = _Context.Userinfo.ToList();
            return Ok(userList);
        }


        //[HttpGet]
        //public IActionResult GetStudents()
        //{
        //   var studentList = _Context.StudentInfo.ToList();
        // return Ok(studentList);
        //}

        // GET: api/UserDB/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userList = _Context.Userinfo.Where(x => x.Id == id);
            return Ok(userList);
        }

        // POST: api/UserDB


        [HttpPost]
        public ActionResult AddUser([FromBody] UserRequest user)
        {
            Userinfo userinfo = new Userinfo();
            userinfo.Name = user.Name;
            userinfo.EmailId = user.EmailId;
            userinfo.Date = user.Date;
            userinfo.Time = user.Time;
            _Context.Userinfo.Add(userinfo);
            _Context.SaveChanges();
            return Ok("User Details Added successfully");
        }


        [HttpPut("{id}")]
        public ActionResult UpdateEvent(int id, [FromBody] Userinfo userRequest)
        {
            Userinfo userinfo = _Context.Userinfo.FirstOrDefault(User => User.Id == id);
            userinfo.Name = userRequest.Name;
            userinfo.EmailId = userRequest.EmailId;
            userinfo.Date = userRequest.Date;
            userinfo.Time = userRequest.Time;
            _Context.Userinfo.Update(userinfo);
            _Context.SaveChanges();
            return Ok(userinfo);
                }

        [HttpDelete("{id}")]
        public ActionResult DeleteEvent(int id)
            {
                var userinfo = _Context.Userinfo.FirstOrDefault(user => user.Id == id);
                _Context.Userinfo.Remove(userinfo);
                _Context.SaveChanges();
                return Ok(userinfo);
            }
        }
    }
       