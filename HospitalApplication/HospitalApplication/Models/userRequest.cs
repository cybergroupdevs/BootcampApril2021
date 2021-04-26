using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApplication.Models
{
    public class UserRequest
    {
        
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Id { get; internal set; }
    }
}
