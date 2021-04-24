using System;
using System.Collections.Generic;

namespace RestroOwners.DbModels
{
    public partial class Restros
    {
        public int Id { get; set; }
        public string RName { get; set; }
        public string RAddress { get; set; }
        public int RPhone { get; set; }
        public string RType { get; set; }
    }
}
