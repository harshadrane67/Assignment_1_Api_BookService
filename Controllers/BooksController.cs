using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using Assignment_1_Api_BookService.Models;
using Books.Entities;
using Assignment_1_Api_BookService.Repository;
using Books.Datalayer;
using Microsoft.AspNetCore.Cors;

namespace Assignment_1_Api_BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository bookRepository;
        private readonly BookDAO bookDAO;

        public BooksController() {
            bookRepository = new BookRepository();
            bookDAO = new BookDAO();
        }

        //Add Book End Point
        [HttpPost, Route("AddBook")]
        public IActionResult AddBook(Book book)
        {
            try
            {
                bookDAO.AddBook(book);
                return StatusCode(200);
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);
            }
        }

        [HttpGet,Route("GetAllBooks")]
        public IActionResult GetAllBooks() {
            try
            {
                List<Book> bookList = bookDAO.getAllBook();
                return StatusCode(200, bookList);
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);
            }
        }

        [HttpGet, Route("GetBooksByAuthor/{AuthorName}")]
        public IActionResult GetBooksByAuthor(string AuthorName)
        {
            try
            {
                return StatusCode(200, bookDAO.GetBookByAuthor(AuthorName));
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);
            }
        }

        //[HttpGet, Route("GetBooksByLang")]
        //public IActionResult GetBooksByLang([FromBody]string Lang)
        //{
        //    try
        //    {
        //        return StatusCode(200, bookRepository.GetBooksByLang(Lang));
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(404, ex.Message);
        //    }
        //}

        //[HttpGet, Route("GetBooksByYear/{Year}")]
        //public IActionResult GetBooksByYear(int Year)
        //{
        //    try
        //    {
        //        return StatusCode(200, bookRepository.GetBooksByYear(Year));
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(404, ex.Message);
        //    }
        //}

        [HttpPut, Route("EditBook")]
        public IActionResult EditBook(int bookId,string bookName,int Price)
        {
            try
            {
                bookDAO.EditBook(bookId,bookName,Price);
                return StatusCode(200);
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);
            }
        }

        [HttpDelete, Route("DeletBook/{bookId}")]
        public IActionResult DeleteBook(int BookId)
        {
            try
            {
                bookDAO.DeleteBook(BookId);
                return StatusCode(200);
            }
            catch (Exception ex)
            {

                return StatusCode(404, ex.Message);
            }
        }
    }
}
