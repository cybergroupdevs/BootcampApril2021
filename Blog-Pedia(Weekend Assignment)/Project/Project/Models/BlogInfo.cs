using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class BlogInfo
    {
        public int BlogId { get; set; }
        public string Head { get; set; }
        public string Body { get; set; }
        public string Username { get; set; }

        public LoginInfo UsernameNavigation { get; set; }
    }
}
