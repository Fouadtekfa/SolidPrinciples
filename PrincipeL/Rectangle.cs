namespace PrincipeL
{
    public class Rectangle : Shape
    {
        public int Hieght { get; set; }
        public int Width { get; set; }

        public override int GetSurface() => Hieght * Width;
    }
}
