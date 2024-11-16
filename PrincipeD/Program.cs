namespace PrincipeD
{
    public class Program
    {
        static void Main(string[] args)
        {

            BookManger(new FileRepository());
            void BookManger(IRepository repository)
            {
                repository.GetAll();
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
