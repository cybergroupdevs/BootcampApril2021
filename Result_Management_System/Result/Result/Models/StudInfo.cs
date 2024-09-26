using System;
using System.Collections.Generic;

namespace Result.Models
{
    public partial class StudInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? English { get; set; }
        public int? Hindi { get; set; }
        public int? Spanish { get; set; }
        public int? Mathematics { get; set; }
        public int? Science { get; set; }
    }
}
