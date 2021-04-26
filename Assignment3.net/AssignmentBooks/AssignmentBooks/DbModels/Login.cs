using System;
using System.Collections.Generic;

namespace AssignmentBooks.DbModels
{
    public partial class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        
        public string Passwords { get; set; }
    }
}
