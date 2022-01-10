using Microsoft.Xna.Framework;

namespace Nez.Svg
{
    public sealed class SvgMoveToSegment : SvgPathSegment
    {
        public SvgMoveToSegment(Vector2 position)
        {
            Start = position;
            End = position;
        }


        public override string ToString()
        {
            return "M" + ToSvgString(Start);
        }
    }
}