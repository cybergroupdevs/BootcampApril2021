using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class AirlineRequest
    {
        //public int Fid { get; set; }
        public string FlightName { get; set; }
        public string FlightDeparture { get; set; }
        public string FlightSource { get; set; }
        public string FlightArrival { get; set; }
        public string Flightdestination { get; set; }
        public int FlightCharges { get; set; }
        public int FlightSeats { get; set; }
    }
}
