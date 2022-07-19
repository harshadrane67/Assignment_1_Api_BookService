using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_1_Api_BookService.Models;

namespace Assignment_1_Api_BookService.Contract
{
    interface IBooksContract
    {
        void AddBook(Book book);

        List<Book> GetAllBooks();
        List<Book> GetBooksByAuthor(string Author);
        List<Book> GetBooksByLang(string lang);
        List<Book> GetBooksByYear(int year);
        void EditBook(Book book);
        void DeleteBook(int bookId);

    }
}
