using System;
using System.Collections.Generic;

namespace TravelBooking.Models
{
    public partial class Logins
    {
        public int Adminid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
