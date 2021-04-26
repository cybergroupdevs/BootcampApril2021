using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cafe.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        ReservationsContext _context;
        public ReservationController(ReservationsContext context)
        {
            _context = context;
        }
        // GET: api/Reservation
        [HttpGet]
        public IActionResult GetAllReservations()
        {
            var reservations = _context.ReservationTable.ToList();
            return Ok(reservations);
        }

        // GET: api/Reservation/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetReservationById(int id)
        {
            var reservations = _context.ReservationTable.FirstOrDefault(studentInfo => studentInfo.Id == id);
            return Ok(reservations);
        }

        // POST: api/Reservation
        [HttpPost]
        public IActionResult AddNewReservation([FromBody] ReservationTable reservations)
        {
            _context.ReservationTable.Add(reservations);
            _context.SaveChanges();
            return Ok("Reservation added successfully");
        }

        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ReservationTable reservationUpdated)
        {
            ReservationTable reservationTable = _context.ReservationTable.FirstOrDefault(reservations => reservations.Id == id);
            reservationTable.Name = reservationUpdated.Name;
            reservationTable.No = reservationUpdated.No;
            _context.ReservationTable.Update(reservationTable);
            _context.SaveChanges();
            return Ok("Updated Your Reservation");


        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var reservations = _context.ReservationTable.FirstOrDefault(reservation => reservation.Id == id);
            _context.ReservationTable.Remove(reservations);
            _context.SaveChanges();
            return Ok("Deleted Your Reservation");
        }
    }
}
