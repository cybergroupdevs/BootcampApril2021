using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public partial class LoginUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Passwrd { get; set; }
    }
}
