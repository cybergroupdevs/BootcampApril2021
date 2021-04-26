using System;
using System.Collections.Generic;

namespace WebApplication8.Models
{
    public partial class Entries
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
    }
}
