using System;
using System.Collections.Generic;

namespace RestroOwners.DbModels
{
    public partial class OwnerRestro
    {
        public int Id { get; set; }
        public string OUserName { get; set; }
        public string OEmail { get; set; }
        public string OPassword { get; set; }
    }
}
