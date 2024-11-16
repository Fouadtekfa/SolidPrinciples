
namespace PrincipeO
{
    public class SurfaceCalculator
    {
        public int ComputeAllSizes(IEnumerable<Shape> shapes)
        {
            int result = 0;

            foreach (var shape in shapes)
            {
                result += shape.Surface;
            }
            return result;
        }

        /*  private int ComputeSize(object shape)
          {
              return shape switch
              {
                  Squar s => s.SideSize * s.SideSize,
                  Rectangle r => r.Hieght * r.Width,
                  _ => throw new InvalidOperationException()
              };
              /*if (shape == null)
              {
                  return 0;

              }else if (shape is Squar squar)
              {
                  return squar.SideSize * squar.SideSize;
              }else if(shape is Rectangle rectangle)
              {
                  return rectangle.Hieght * rectangle.Hieght;
              }
              else
              {
                  throw new InvalidOperationException();

              }*/
        //   }
    }
}
