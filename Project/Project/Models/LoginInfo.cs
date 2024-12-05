using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class LoginInfo
    {
        public LoginInfo()
        {
            BlogInfo = new HashSet<BlogInfo>();
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<BlogInfo> BlogInfo { get; set; }
    }
}
