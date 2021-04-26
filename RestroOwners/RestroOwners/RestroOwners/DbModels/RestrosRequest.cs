using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestroOwners.DbModels
{
    public class RestrosRequest
    {
        public string RName { get; set; }
        public string RAddress { get; set; }
        public string RPhone { get; set; }
        public string RType { get; set; }
    }
}
