using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_1_Api_BookService.Contract;
using Assignment_1_Api_BookService.Models;

namespace Assignment_1_Api_BookService.Repository
{
    public class BookRepository : IBooksContract
    {
        public List<Book> listBooks = new List<Book>() {
            new Book() {BookId=1,BookName="Book1",Author="xyz",lang="eng",year=new DateTime(2021,12,13),Price=200 }
        };
        public void AddBook(Book book)
        {
            Console.WriteLine(book);
            listBooks.Add(book);
        }

        public void DeleteBook(int bookId)
        {
            Book book = listBooks.Single(book=>book.BookId == bookId);
            listBooks.Remove(book);
        }

        public void EditBook(Book book)
        {
            for (int i = 0; i < listBooks.Count(); i++) {
                if (book.BookId == listBooks[i].BookId) {
                    listBooks[i].BookId = book.BookId;
                    listBooks[i].Author = book.Author;
                    listBooks[i].BookName = book.BookName;
                    listBooks[i].lang = book.lang;
                    listBooks[i].Price = book.Price;
                    listBooks[i].year = book.year;
                    break;
                }
            }
        }

        public List<Book> GetAllBooks()
        {
            return listBooks;
        }

        public List<Book> GetBooksByAuthor(string Author)
        {
            return listBooks.Where(book => book.Author == Author).ToList();
        }

        public List<Book> GetBooksByLang(string lang)
        {
            return listBooks.Where(book => book.lang == lang).ToList();
        }

        public List<Book> GetBooksByYear(int year)
        {
            return listBooks.Where(book => book.year.Year == year).ToList();
        }
    }
}
