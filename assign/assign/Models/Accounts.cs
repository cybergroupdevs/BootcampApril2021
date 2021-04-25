using System;
using System.Collections.Generic;

namespace assign.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            Users = new HashSet<Users>();
        }

        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string City { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
