namespace PrincipeD
{
    public interface IWriteIRepository
    {
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
        Task Save();
    }
}
