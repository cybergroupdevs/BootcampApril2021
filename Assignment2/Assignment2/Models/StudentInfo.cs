using System;
using System.Collections.Generic;

namespace Assignment2.DbModels
{
    public partial class StudentInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
