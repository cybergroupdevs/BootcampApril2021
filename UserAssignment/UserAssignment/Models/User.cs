using System;
using System.Collections.Generic;

namespace UserAssignment.Models
{
    public partial class User
    {
        //6 columns
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Doubt { get; set; }
        public string Resolver { get; set; }
        public string Solution { get; set; }
    }
}
