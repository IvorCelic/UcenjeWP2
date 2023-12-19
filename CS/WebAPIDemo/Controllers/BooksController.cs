﻿using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BooksController: ControllerBase
    {
        [HttpGet]
        public string GetBooks()
        {
            return "Izlistavam sve knjige.";
        }

        [HttpGet("{ID}")]
        public string GetBookByID(int ID)
        {
            return $"Iščitavam knjigu: {ID}";
        }

        [HttpPost]
        public string CreateBook([FromBody]Book book) 
        {
            return $"Kreiram knjigu.";
        }

        [HttpPut("{ID}")]
        public string UpdateBook(int ID)
        {
            return $"Ažuriram knjigu: {ID}";
        }

        [HttpDelete("{ID}")]
        public string DeleteBook(int ID)
        {
            return $"Brišem knjigu: {ID}";
        }
    }
}
