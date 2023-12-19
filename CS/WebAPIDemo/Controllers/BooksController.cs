using Microsoft.AspNetCore.Mvc;
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
            return Ok("Izlistavam sve knjige.");
        }


        [HttpGet("{ID}")]
        public IActionResult GetBookByID(int ID)
        {
            if (ID <= 0)
                return BadRequest();

            var book = BookRepository.GetBookByID(ID);
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
