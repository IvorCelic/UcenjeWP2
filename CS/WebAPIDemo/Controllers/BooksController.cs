using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    public class BooksController: ControllerBase
    {
        [HttpGet]
        [Route("/books")]
        public string GetBooks()
        {
            return "izlistavam sve knjige.";
        }

        [HttpGet]
        [Route("/books/{ID}")]
        public string GetBookByID(int ID)
        {
            return $"Iščitavam knjigu: {ID}";
        }

        [HttpPost]
        [Route("/books")]
        public string CreateBook() 
        {
            return $"Kreiram knjigu.";
        }

        [HttpPut]
        [Route("/books/{ID}")]
        public string UpdateBook(int ID)
        {
            return $"Ažuriram knjigu: {ID}";
        }

        [HttpDelete]
        [Route("/books/{ID}")]
        public string DeleteBook(int ID)
        {
            return $"Brišem knjigu: {ID}";
        }
    }
}
