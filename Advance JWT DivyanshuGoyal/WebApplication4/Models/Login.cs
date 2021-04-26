using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Username { get; internal set; }
        public string Passwords { get; internal set; }
    }
}