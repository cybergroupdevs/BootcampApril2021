using System;
using System.Collections.Generic;

namespace WebApplication4.DBModels
{
    public partial class Account
    {
        public Account()
        {
            Users = new HashSet<Users>();
        }

        public int AccId { get; set; }
        public string AccName { get; set; }
        public string City { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
