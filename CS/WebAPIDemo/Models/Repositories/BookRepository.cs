namespace WebAPIDemo.Models.Repositories
{
    public static class BookRepository
    {
        private static List<Book> books = new List<Book>()
        {
            new Book {BookID = 1, Title = "Rat i Mir", Author = "Lav Nikolajevič Tolstoj", Category = "Roman", NumberOfPages = 100, Price = 30},
            new Book {BookID = 2, Title = "Siddartha", Author = "Herman Hesse", Category = "Roman", NumberOfPages = 143, Price = 15}
        };

        public static bool BookExists(int ID)
        {
            return books.Any(x => x.BookID == ID);
        }

        public static Book? GetBookByID(int ID)
        {
            return books.FirstOrDefault(x => x.BookID == ID);
        }

    }
}
