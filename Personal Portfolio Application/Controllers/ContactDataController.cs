using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment_net1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_net1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDataController : ControllerBase
    {

        StudentDBContext _context;
        public ContactDataController(StudentDBContext context)
        {
            _context = context;
        }

        // GET: api/ContactData
        [Authorize]
        [HttpGet]
        public IActionResult GetContactData()
        {
            var ContactDataList = _context.ContactInfo.ToList();
            return Ok(ContactDataList);
        }

        // POST: api/ContactData
        [HttpPost]
        public IActionResult AddContactData([FromBody] ContactRequest temp)
        {
            ContactInfo contact = new ContactInfo();
            contact.Name = temp.Name;
            contact.Email = temp.Email;
            contact.ProjectName = temp.ProjectName;
            contact.Message = temp.Message;
            _context.ContactInfo.Add(contact);
            _context.SaveChanges();
            return Ok("Successfully Added");
        }

        // PUT: api/ContactData/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateContactData(int id, [FromBody] ContactRequest temp)
        {
            ContactInfo contact = _context.ContactInfo.FirstOrDefault(cont => cont.Id == id);
            contact.Name = temp.Name;
            contact.Email = temp.Email;
            contact.ProjectName = temp.ProjectName;
            contact.Message = temp.Message;
            _context.ContactInfo.Update(contact);
            _context.SaveChanges();
            return Ok("Data is Updated");
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult RemoveContactData(int id)
        {
            var contact = _context.ContactInfo.FirstOrDefault(cont => cont.Id == id);
            _context.ContactInfo.Remove(contact);
            _context.SaveChanges();
            return Ok("Data is Deleted");
        }
    }
}
