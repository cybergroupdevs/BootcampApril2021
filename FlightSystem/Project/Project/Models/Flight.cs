using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Flight
    {

        public int Fid { get; set; }
        public string FlightName { get; set; }
        public string FlightDeparture { get; set; }
        public string FlightSource { get; set; }
        public string FlightArrival { get; set; }
        public string Flightdestination { get; set; }
        public int FlightCharges { get; set; }
        public int FlightSeats { get; set; }
        //public object Flight { get; internal set; }
    }
}
