using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Filters;
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
        public IActionResult CreateBook([FromBody]Book book) 
        {
            if (book == null) return BadRequest();

            var existingBook = BookRepository.GetBookByProperties(book.Title, book.Author, book.Category, book.NumberOfPages);
            if (existingBook != null) return BadRequest();

            BookRepository.AddBook(book);

            return CreatedAtAction(nameof(GetBookByID),
                new { ID = book.BookID },
                book);
        }


        [HttpPut("{ID}")]
        public IActionResult UpdateBook(int ID)
        {
            return Ok($"Ažuriram knjigu: {ID}");
        }


        [HttpDelete("{ID}")]
        public IActionResult DeleteBook(int ID)
        {
            return Ok($"Brišem knjigu: {ID}");
        }
    }
}
