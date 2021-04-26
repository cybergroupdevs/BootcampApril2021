using System;
using System.Collections.Generic;

namespace BankManagementSystem.Models
{
    public partial class BankInfo
    {
        public int Id { get; set; }
        public int? AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public int? IfscCode { get; set; }
        public int? Amount { get; set; }
    }
}
