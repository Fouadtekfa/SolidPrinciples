namespace PrincipeI
{
    public class BookRepository : IBookRepository
    {
        //private List<Book> books = new();
        //ici just pour avoir une list 
        private List<Book> books = new List<Book>
            {
                new Book { Id = 1, Titel = "Le Petit Prince", Author = "Antoine de Saint-Exupéry", NbPages = 96, ISBN = "9780156012195" },
                new Book { Id = 2, Titel = "1984", Author = "George Orwell", NbPages = 328, ISBN = "9780451524935" },
                new Book { Id = 3, Titel = "To Kill a Mockingbird", Author = "Harper Lee", NbPages = 281, ISBN = "9780060935467" },
                new Book { Id = 4, Titel = "The Great Gatsby", Author = "F. Scott Fitzgerald", NbPages = 180, ISBN = "9780743273565" },
                new Book { Id = 5, Titel = "Moby Dick", Author = "Herman Melville", NbPages = 635, ISBN = "9781503280786" }
            };
        public void Add(Book book)
        => books.Add(book);
        public void Delete(Book book)
         => books.Remove(book);
        public IEnumerable<Book> GetAll()
         => books;

        public Book? GetByID(int id)
         => books.FirstOrDefault(b => b.Id == id);

        public Task Save()
         => Task.CompletedTask;

        public void Update(Book book)
         => books.RemoveAll(b => b.Id == book.Id);
    }
}
