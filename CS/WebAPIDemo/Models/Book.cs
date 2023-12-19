using System.ComponentModel.DataAnnotations;

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
        public double Price { get; set; }
    }
}
