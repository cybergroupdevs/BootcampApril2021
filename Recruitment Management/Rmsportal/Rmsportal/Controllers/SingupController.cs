using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rmsportal.Models;

namespace Rmsportal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingupController : ControllerBase
    {

        RmsContext _Context;
        public SingupController(RmsContext context)
        {
            _Context = context;
        }
        // POST: api/Singup
        [HttpPost]
        public IActionResult createuser([FromBody]Signup temp)
        {
            var Users = _Context.Clogin.ToList();
            var user = Users.FirstOrDefault(x => (x.UserName == temp.UserName) || (x.Email == temp.Email));
            //check for not unique values in database
            if (user != null)
            {
                return StatusCode(406);
            }
            else if (temp.UserName == "" || temp.Password == "" || temp.Email == "")
            {
                return StatusCode(406);
            }
            else
            {
                Clogin Infoadded = new Clogin();
                Infoadded.UserName = temp.UserName;
                Infoadded.Password = temp.Password;
                Infoadded.Email = temp.Email;
                _Context.Clogin.Add(Infoadded);
                _Context.SaveChanges();
                return Ok();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Temp = _Context.Clogin.FirstOrDefault(x => x.Cid == id);
            _Context.Clogin.Remove(Temp);
            _Context.SaveChanges();
            return Ok("Deleted");
        }


    }
}
