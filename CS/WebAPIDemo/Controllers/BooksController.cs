using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BooksController: ControllerBase
    {
        private List<Book> books = new List<Book>()
        {
            new Book {BookID = 1, Title = "Rat i Mir", Author = "Lav Nikolajevič Tolstoj", Category = "Roman", Price = 30},
            new Book {BookID = 2, Title = "Siddartha", Author = "Herman Hesse", Category = "Roman", Price = 15}
        };

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok("Izlistavam sve knjige.");
        }

        [HttpGet("{ID}")]
        public IActionResult GetBookByID(int ID)
        {
            if (ID <= 0)
                return BadRequest();

            var book = books.First(x => x.BookID == ID);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody]Book book) 
        {
            return Ok($"Kreiram knjigu.");
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
