using System;
using System.Collections.Generic;

namespace TravelBooking.Models
{
    public partial class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Bdate { get; set; }
        public string Flightname { get; set; }
        public string Address { get; set; }
        public string Time { get; set; }
    }
}
