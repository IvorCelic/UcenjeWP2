using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVCCourse.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("Category")]
        public Category Category { get; set; }

    }
}
