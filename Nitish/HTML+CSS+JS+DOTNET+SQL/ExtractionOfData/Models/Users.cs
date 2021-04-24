using System;
using System.Collections.Generic;

namespace ExtractionOfData.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public int? AccountId { get; set; }

        public Accounts Account { get; set; }
    }
}
