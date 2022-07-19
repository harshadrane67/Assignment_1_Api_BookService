using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1_Api_BookService.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
        public string lang { get; set; }
        public DateTime year { get; set; }

    }
}
