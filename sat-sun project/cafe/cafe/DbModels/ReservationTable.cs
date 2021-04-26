using System;
using System.Collections.Generic;

namespace cafe.DbModels
{
    public partial class ReservationTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? No { get; set; }
        public int? ContactNo { get; set; }
        public string DateTime { get; set; }
        public string Message { get; set; }
    }
}
