using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class LoginInfo
    {
        public LoginInfo()
        {
            UsersInfo = new HashSet<UsersInfo>();
        }

        public string InternId { get; set; }
        public string Password { get; set; }

        public ICollection<UsersInfo> UsersInfo { get; set; }
    }
}
