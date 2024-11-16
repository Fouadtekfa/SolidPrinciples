namespace PrincipeL
{
    public class Squar : ShapeWithSurface
    {
        public int SideSize { get; set; }

        public override int GetSurface() => SideSize * SideSize;
    }
}
