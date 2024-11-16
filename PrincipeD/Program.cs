namespace PrincipeD
{
    public class Program
    {

        

        static void Main(string[] args)
        {
            BookRepository bookRepository = new BookRepository();
            void BookManger(BookRepository bookRepository)
            {
                bookRepository.GetAll();
                //Menu pour gerer
                // 1 GetAll
                //2 GetByID
                //3 update
                //......
                //....

            }

            
        }
    }
}
