using Microsoft.Xna.Framework;

namespace Nez.Svg
{
    public sealed class SvgLineSegment : SvgPathSegment
    {
        public SvgLineSegment(Vector2 start, Vector2 end)
        {
            Start = start;
            End = end;
        }


        public override string ToString()
        {
            return "L" + ToSvgString(End);
        }
    }
}