namespace WebAPIDemo.Models.Repositories
{
    public static class BookRepository
    {
        private static List<Book> books = new List<Book>()
        {
            new Book {BookID = 1, Title = "Rat i Mir", Author = "Lav Nikolajevič Tolstoj", Category = "Roman", NumberOfPages = 100, Price = 30},
            new Book {BookID = 2, Title = "Siddartha", Author = "Herman Hesse", Category = "Roman", NumberOfPages = 143, Price = 15}
        };

        public static List<Book> GetBooks()
        {
            return books;
        }

        public static bool BookExists(int ID)
        {
            return books.Any(x => x.BookID == ID);
        }

        public static Book? GetBookByID(int ID)
        {
            return books.FirstOrDefault(x => x.BookID == ID);
        }

        public static Book? GetBookByProperties(string? title, string? author, string? category, int? numberofpages)
        {
            return books.FirstOrDefault(x =>
                !string.IsNullOrWhiteSpace(title) &&
                !string.IsNullOrWhiteSpace(x.Title) &&
                x.Title.Equals(title, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(author) &&
                !string.IsNullOrWhiteSpace(x.Author) &&
                x.Author.Equals(author, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(category) &&
                !string.IsNullOrWhiteSpace(x.Category) &&
                x.Category.Equals(category, StringComparison.OrdinalIgnoreCase) &&
                numberofpages.HasValue &&
                x.NumberOfPages.HasValue &&
                numberofpages.Value == x.NumberOfPages.Value);
        }

        public static void AddBook(Book book)
        {
            int maxID = books.Max(x => x.BookID);
            book.BookID = maxID + 1;

            books.Add(book);
        }

    }
}
