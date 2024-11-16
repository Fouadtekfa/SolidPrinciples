namespace PrincipeI
{
    public class Program
    {
        public void DisplayAllBook(IReadRepository repo)
        {
            var books = repo.GetAll().ToList();
            foreach (var book in books)
            { 
                Console.WriteLine(book.Titel);
                //je provoque une erreur de compilation 
                //repo.Delete(book);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.DisplayAllBook(new BookRepository());
        }
    }
}
