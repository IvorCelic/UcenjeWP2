using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Models.Validations
{
    public class Book_EnsureCorrectNumberOfPagesAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var book = validationContext.ObjectInstance as Book;

            if (book != null && !string.IsNullOrWhiteSpace(book.Category))
            {
                if (book.Category.Equals("Roman", StringComparison.OrdinalIgnoreCase) && book.NumberOfPages < 50)
                {
                    return new ValidationResult("Za kategoriju roman, broj stranica mora biti jednak ili veći od 50.");
                }
                else if (book.Category.Equals("Bajka", StringComparison.OrdinalIgnoreCase) && book.NumberOfPages < 5) {
                    return new ValidationResult("Za kategoriju bajka, broj stranica mora biti jednak ili veći od 5.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
