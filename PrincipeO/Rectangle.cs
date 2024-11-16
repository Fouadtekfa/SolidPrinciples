namespace PrincipeO
{
    public class Rectangle : Shape
    {
        public int Hieght { get; set; }
        public int Width { get; set; }

        public override int Surface => Hieght * Width;
    }
}
