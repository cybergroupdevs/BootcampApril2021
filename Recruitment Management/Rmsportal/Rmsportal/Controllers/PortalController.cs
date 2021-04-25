using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rmsportal.Models;

namespace Rmsportal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortalController : ControllerBase
    {

        RmsContext _Context;
        public PortalController(RmsContext context)
        {
            _Context = context;
        }

        // GET: api/Portal
        [HttpGet]
        public IActionResult Getvalues()
        {
            var student = _Context.RmsInfo.ToList();
            return Ok(student);
        }

        // GET: api/Portal/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Portal
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]RmsRequest temp)
        {
            RmsInfo Infoadded = new RmsInfo();
            Infoadded.Cname = temp.Cname;
            Infoadded.Designation = temp.Designation;
            Infoadded.Drole = temp.Drole;
            Infoadded.Availabile = temp.Availabile;
            _Context.RmsInfo.Add(Infoadded);
            _Context.SaveChanges();
            return Ok("Added");
        }

        // PUT: api/Portal/5
        [HttpPut("{id}")]
        
        public IActionResult Put(int id, [FromBody]RmsRequest temp)
        {
            RmsInfo InfoUpdate = _Context.RmsInfo.FirstOrDefault(x => x.Id == id);
            InfoUpdate.Cname = temp.Cname;
            InfoUpdate.Designation = temp.Designation;
            InfoUpdate.Drole = temp.Drole;
            InfoUpdate.Availabile = temp.Availabile;
            _Context.RmsInfo.Update(InfoUpdate);
            _Context.SaveChanges();
            return Ok("Updated");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var Temp = _Context.RmsInfo.FirstOrDefault(x => x.Id == id);
            _Context.RmsInfo.Remove(Temp);
            _Context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
