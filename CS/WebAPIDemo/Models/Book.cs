using System.ComponentModel.DataAnnotations;
using WebAPIDemo.Models.Validations;

namespace WebAPIDemo.Models
{
    public class Book
    {
        public int BookID { get; set; }


        [Required]
        public string? Title { get; set; }


        [Required]
        public string? Author { get; set; }


        [Required]
        public string? Category { get; set; }


        [Book_EnsureCorrectNumberOfPages]
        public int? NumberOfPages { get; set; }
        
        public double Price { get; set; }
    }
}
