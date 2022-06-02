using Microsoft.Xna.Framework;

namespace Nez.Svg
{
    public sealed class SvgCubicCurveSegment : SvgPathSegment
    {
        public Vector2 FirstCtrlPoint;
        public Vector2 SecondCtrlPoint;


        public SvgCubicCurveSegment(Vector2 start, Vector2 firstCtrlPoint, Vector2 secondCtrlPoint, Vector2 end)
        {
            Start = start;
            End = end;
            FirstCtrlPoint = firstCtrlPoint;
            SecondCtrlPoint = secondCtrlPoint;
        }


        public override string ToString()
        {
            return "C" + ToSvgString(FirstCtrlPoint) + " " + ToSvgString(SecondCtrlPoint) + " " + ToSvgString(End);
        }
    }
}