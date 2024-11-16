namespace PrincipeL
{
    public class Squar : Shape
    {
        public int SideSize { get; set; }

        public override int GetSurface() => SideSize * SideSize;
    }
}
