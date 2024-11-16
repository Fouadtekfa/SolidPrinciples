namespace PrincipeI
{
    public class Program
    {
        public void DisplayAllBook(IBookRepository repo)
        {
            var books = repo.GetAll().ToList();
            foreach (var book in books)
            { 
                Console.WriteLine(book.Titel);
                repo.Delete(book);
            }



        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.DisplayAllBook(new BookRepository());


        }
    }
}
