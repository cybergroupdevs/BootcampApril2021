using System;
using System.Collections.Generic;

namespace WebApplication4.DBModels
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AccId { get; set; }

        public Account Acc { get; set; }
    }
}
