using System;

namespace Books.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
        public DateTime year { get; set; }
    }
}
