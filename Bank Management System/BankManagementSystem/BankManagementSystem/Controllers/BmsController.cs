using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BmsController : ControllerBase
    {
        // GET: api/Bms
        BankDBContext _context;
        public BmsController(BankDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = _context.BankInfo.ToList();
            return Ok(users);
        }

        // GET: api/Bms/5
        [HttpGet("{id}")]
        public IActionResult UserById(int id)
        {
            var user = _context.BankInfo.FirstOrDefault(UserInfo => UserInfo.Id == id);
            return Ok(user);
        }

        // POST: api/Bms

        [HttpPost]
        public IActionResult NewUser([FromBody] BankInfo user)
        {
            _context.BankInfo.Add(user);
            _context.SaveChanges();
            return Ok("User Added Successfully!!");
        }

        // PUT: api/Bms/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] BankInfo UserUpdated)
        {
            BankInfo UserInfo = _context.BankInfo.FirstOrDefault(user => user.Id == id);
            UserInfo.AccountNumber = UserUpdated.AccountNumber;
            UserInfo.AccountHolderName = UserUpdated.AccountHolderName;
            UserInfo.Age = UserUpdated.Age;
            UserInfo.Address = UserUpdated.Address;
            UserInfo.IfscCode = UserUpdated.IfscCode;
            UserInfo.Amount = UserUpdated.Amount;
            _context.BankInfo.Update(UserInfo);
            _context.SaveChanges();
            return Ok("User Updated Successfully!!");
        }

        // DELETE: api/Bms/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.BankInfo.FirstOrDefault(UserInfo => UserInfo.Id == id);
            _context.BankInfo.Remove(user);
            _context.SaveChanges();
            return Ok("User Deleted Successfully!!");
        }
    }
}
