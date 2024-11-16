namespace PrincipeL
{
    public class Rectangle : ShapeWithSurface
    {
        public int Hieght { get; set; }
        public int Width { get; set; }

        public override int GetSurface() => Hieght * Width;
    }
}
