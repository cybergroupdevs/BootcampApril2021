using System;
using System.Collections.Generic;

namespace HospitalApplication.Models
{
    public partial class Userinfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
