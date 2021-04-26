using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardDataBaseController : ControllerBase
    {
        GuardContext _context;
        public GuardDataBaseController(GuardContext context)
        {
            _context = context;
        }
        // GET: api/<GuardDataBaseController>
        [HttpGet]
       [Authorize]
        public IActionResult GetAllEntries()
        {
            var entries = _context.Entries.ToList();
            return Ok(entries);
        }

        // GET api/<GuardDataBaseController>/5
        [HttpGet("{id}")]
        public IActionResult GetEntryById(int id)
        {
            var entry = _context.Entries.FirstOrDefault(entryInfo => entryInfo.Id == id);
            return Ok(entry);
        }

        // POST api/<GuardDataBaseController>
        [HttpPost]
        public IActionResult AddNewEntry([FromBody] Entries entry)
        {
            _context.Entries.Add(entry);
            _context.SaveChanges();
            return Ok("User entered");
        }

        // PUT api/<GuardDataBaseController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateEntry(int id, [FromBody] Entries updatedEntry)
        {
            Entries enter = _context.Entries.FirstOrDefault(user => user.Id == id);
            enter.EmployeeId = updatedEntry.EmployeeId;
            enter.Name = updatedEntry.Name;
            enter.Contact = updatedEntry.Contact;
            enter.Location = updatedEntry.Location;
            _context.Entries.Update(enter);
            _context.SaveChanges();
            return Ok("Updated");


        }

        // DELETE api/<GuardDataBaseController>/5

        [HttpDelete("{id}")]
        public IActionResult DeleteEntry(int id)
        {
            var entry = _context.Entries.FirstOrDefault(enterInfo => enterInfo.Id == id);
            _context.Entries.Remove(entry);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
