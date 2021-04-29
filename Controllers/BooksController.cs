using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_books.Data.Services;
using My_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService _bookservice;

        public BooksController(BookService bookService)
        {
            _bookservice = bookService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookservice.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookservice.getBookById(id);
            return Ok(book);
        }

        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookservice.AddBookWithAuthors(book);
            return Ok();
        }        

        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBook(int id, [FromBody]BookVM book)
        {
            var updatedBook = _bookservice.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookservice.DeleteBook(id);
            return Ok();
        }
    }
}
