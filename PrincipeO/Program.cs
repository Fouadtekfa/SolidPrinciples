namespace PrincipeO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape>
            {
                new Rectangle { Hieght = 10, Width = 5},
                new Squar { SideSize = 4},
                new Rectangle { Hieght = 7, Width= 3}
            };
            var calulator = new SurfaceCalculator();
            int totalSurface = calulator.ComputeAllSizes(shapes);
            Console.WriteLine($"total Surface {totalSurface}");
        }
    }
}
