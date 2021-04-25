using System;
using System.Collections.Generic;

namespace assign.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int? AccountId { get; set; }

        public Accounts Account { get; set; }
    }
}
