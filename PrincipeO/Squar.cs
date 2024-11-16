namespace PrincipeO
{
    public class Squar : Shape
    {
        public int SideSize { get; set; }

        public override int Surface => SideSize * SideSize;
    }
}
