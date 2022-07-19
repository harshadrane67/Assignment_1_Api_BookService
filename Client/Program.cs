using System;
using Client.Services;
using Books.Entities;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            BookServices bookServices = new BookServices();
            do
            {
                Console.WriteLine("1.GetAllBooks\n2.GetBook\n3.AddBook\n4.DeleteBook\n5.EditBook\n6.Exit");
                Console.WriteLine("Enter Choice");
                byte ch = byte.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        {
                            //Get All Employees
                            List<Book> bookList = bookServices.GetAllBook();
                            foreach (var book in bookList)
                            {
                                Console.WriteLine($"Id:{book.BookId} Name:{book.BookName} Author:{book.Author}");
                            }
                        }
                        break;
                    case 2:
                        {
                            //Get Employee
                            Console.WriteLine("Enter Author Name");
                            string authorName = Console.ReadLine();
                            List<Book> booklist = bookServices.GetBookByAuthor(authorName);

                            if (booklist != null)
                            {
                                foreach (var book in booklist)
                                {
                                    Console.WriteLine($"Id:{book.BookId} Name:{book.BookName} Author:{book.Author}");
                                }
                            }
                            else
                                Console.WriteLine("Invalid AuthorName");
                        }
                        break;
                    case 3:
                        {
                            //Add Employee
                            Book book = new Book();

                            Console.WriteLine("Enter BookName");
                            book.BookName = Console.ReadLine();
                            Console.WriteLine("Enter Year");
                            book.year = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Price");
                            book.Price = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Author Name");
                            book.Author = Console.ReadLine();
                            bookServices.AddBook(book);

                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Enter BookId");
                            int id = int.Parse(Console.ReadLine());
                            bookServices.DeleteBook(id);
                        }
                        break;
                    case 5:
                        {

                            Console.WriteLine("Enter Book Id");
                            int bookId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter BookName");
                            string bookName = Console.ReadLine();
                            Console.WriteLine("Enter Price");
                            int price = int.Parse(Console.ReadLine());
                            
                            bookServices.EditBook(bookId,bookName,price);
                        }
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;

                }
            } while (true);
        }
    }
}
