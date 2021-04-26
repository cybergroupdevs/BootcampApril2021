using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBooking.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        
// GET: api/Airline
bookingportalContext _context;
        public BookingController(bookingportalContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult GetCustomer()
        {
            var cusList = _context.Customers.ToList();
            return Ok(cusList);
        }



        // GET: api/Airline
        [HttpGet("{id}", Name = "Get")]
        public Customers GetUserByID(int id)
        {
            var user = _context.Customers.FirstOrDefault(Customers=> Customers.Id == id);
            return user;
        }



        // POST: api/Airline
        [HttpPost]
        public ActionResult AddCustomer([FromBody] Customers customer)
        {
            Customers temp = new Customers()
            {
                Id=customer.Id,
                Name = customer.Name,
                Age = customer.Age,
                Bdate = customer.Bdate,
                Flightname = customer.Flightname,
                Address = customer.Address,
                Time = customer.Time
               
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok("Customer Added successfully");
        }



        // PUT: api/Airline/5
        [HttpPut("{id}")]
        public ActionResult Edit(int id, [FromBody] Customers customer_req)
        {
            Customers cusInfo = GetUserByID(id);
            cusInfo.Name = customer_req.Name;
            cusInfo.Age = customer_req.Age;
            cusInfo.Bdate = customer_req.Bdate;
            cusInfo.Flightname = customer_req.Flightname;
            cusInfo.Address= customer_req.Address;
            cusInfo.Time = customer_req.Time;
            _context.SaveChanges();
            return Ok("customer updated!");
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var demo = GetUserByID(id);
            _context.Customers.Remove(demo);
            _context.SaveChanges();
            return Ok(demo);
        }
    }
}