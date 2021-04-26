using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class UsersInfo
    {
        public string FullName { get; set; }
        public string InternId { get; set; }
        public string UserName { get; set; }
        public string Projects { get; set; }
        public string TechStack { get; set; }

        public LoginInfo Intern { get; set; }
    }
}
