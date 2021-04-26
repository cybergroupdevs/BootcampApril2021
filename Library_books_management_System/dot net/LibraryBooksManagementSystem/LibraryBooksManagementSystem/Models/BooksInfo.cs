using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBooksManagementSystem.Models
{
    public class BooksInfo
    {
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int? BookCost { get; set; }
        public int? BookIssued { get; set; }
        public int? BookAvailable { get; set; }
    }
}
