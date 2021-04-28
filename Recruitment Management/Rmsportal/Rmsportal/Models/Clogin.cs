using System;
using System.Collections.Generic;

namespace Rmsportal.Models
{
    public partial class Clogin
    {
        public int Cid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
