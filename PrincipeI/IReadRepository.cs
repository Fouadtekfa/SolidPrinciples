namespace PrincipeI
{
    public interface IReadRepository
    {
        Book? GetByID(int id);
        IEnumerable<Book> GetAll();
    }
}
