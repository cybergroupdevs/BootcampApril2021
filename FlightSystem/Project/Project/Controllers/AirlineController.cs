using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        // GET: api/Airline
        FlightContext _context;
        public AirlineController(FlightContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult GetCustomer()
        {
            var cusList = _context.Flight.ToList();
            return Ok(cusList);
        }

        // GET: api/Airline
        [HttpGet("{id}", Name = "Get")]
        public Flight GetUserByID(int id)
        {
            var user = _context.Flight.FirstOrDefault(Flight => Flight.Fid == id);
            return user;
        }

        // POST: api/Airline
        [HttpPost]
        [Authorize]
        public ActionResult AddCustomer([FromBody]AirlineRequest customer)
        {
            Flight temp = new Flight()
            {
                FlightName = customer.FlightName,
                FlightDeparture = customer.FlightDeparture,
                FlightSource = customer.FlightSource,
                FlightArrival = customer.FlightArrival,
                Flightdestination = customer.Flightdestination,
                FlightCharges = customer.FlightCharges,
                FlightSeats = customer.FlightSeats
            };
            _context.Flight.Add(temp);
            _context.SaveChanges();
            return Ok("Customer Added successfully");
        }

        // PUT: api/Airline/5
        [HttpPut("{id}")]
        //[Authorize]
        public ActionResult Edit(int id, [FromBody]AirlineRequest customer_req)
        {
            Flight cusInfo = GetUserByID(id);
            cusInfo.FlightName = customer_req.FlightName;
            cusInfo.FlightDeparture = customer_req.FlightDeparture;
            cusInfo.FlightSource = customer_req.FlightSource;
            cusInfo.FlightArrival = customer_req.FlightArrival;
            cusInfo.Flightdestination = customer_req.Flightdestination;
            cusInfo.FlightCharges = customer_req.FlightCharges;
            cusInfo.FlightSeats = customer_req.FlightSeats;
            _context.SaveChanges();
            return Ok("customer updated!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var demo = GetUserByID(id);
            _context.Flight.Remove(demo);
            _context.SaveChanges();
            return Ok(demo);
        }
    }
}
