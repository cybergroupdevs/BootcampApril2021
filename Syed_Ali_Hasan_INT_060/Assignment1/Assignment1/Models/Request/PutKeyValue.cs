using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models.Request
{
    public class PutKeyValueString
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class PutKeyValueInt
    {
        public int key { get; set; }
        public int value { get; set; }
    }
}
