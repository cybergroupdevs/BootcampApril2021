using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentBooks.DbModels
{
    public class LoginRequest
    {
        public string UserName { get; set; }

        public string Passwords { get; set; }
    }
}
