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
    public class SignUpController : ControllerBase
    {
        StudDBContext _context;
        public SignUpController(StudDBContext context)
        {
            _context = context;
        }
        // POST: api/SignUp
        [HttpPost]
        public ActionResult AddUser([FromBody]LoginInfo stud)
        {
            _context.LoginInfo.Add(stud);
            _context.SaveChanges();
            return Ok("Details Added");

        }
    }
}
