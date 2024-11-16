namespace PrincipeI
{
    public interface IBookRepository
    {
        Book? GetByID(int id);
        IEnumerable<Book> GetAll();
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
        Task Save();

    }
}
