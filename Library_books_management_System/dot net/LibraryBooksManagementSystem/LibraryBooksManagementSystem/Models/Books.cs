using System;
using System.Collections.Generic;

namespace LibraryBooksManagementSystem.Models
{
    public partial class Books
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int? BookCost { get; set; }
        public int? BookIssued { get; set; }
        public int? BookAvailable { get; set; }
    }
}
