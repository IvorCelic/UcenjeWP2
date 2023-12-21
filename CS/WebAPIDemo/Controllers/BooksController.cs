using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Filters.ActionFilters;
using WebAPIDemo.Filters.ExceptionFilters;
using WebAPIDemo.Models;
using WebAPIDemo.Models.Repositories;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BooksController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(BookRepository.GetBooks());
        }


        [HttpGet("{ID}")]
        [Book_ValidateBookIDFilter]
        public IActionResult GetBookByID(int ID)
        {
            return Ok(BookRepository.GetBookByID(ID));
        }


        [HttpPost]
        [Book_ValidateCreateBookFilter]
        public IActionResult CreateBook([FromBody]Book book) 
        {
            BookRepository.AddBook(book);

            return CreatedAtAction(nameof(GetBookByID),
                new { ID = book.BookID },
                book);
        }


        [HttpPut("{ID}")]
        [Book_ValidateBookIDFilter]
        [Book_ValidateUpdateBookFilter]
        [Book_HandleUpdateExceptionsFilter]

        public IActionResult UpdateBook(int ID, Book book)
        {
            BookRepository.UpdateBook(book);

            return NoContent();
        }


        [HttpDelete("{ID}")]
        public IActionResult DeleteBook(int ID)
        {
            return Ok($"Brišem knjigu: {ID}");
        }
    }
}
