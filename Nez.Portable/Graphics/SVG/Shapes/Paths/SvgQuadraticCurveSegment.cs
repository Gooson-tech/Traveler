using Microsoft.Xna.Framework;

namespace Nez.Svg
{
    public sealed class SvgQuadraticCurveSegment : SvgPathSegment
    {
        public Vector2 ControlPoint;

        public Vector2 FirstCtrlPoint
        {
            get
            {
                var x1 = Start.X + (ControlPoint.X - Start.X) * 2 / 3;
                var y1 = Start.Y + (ControlPoint.Y - Start.Y) * 2 / 3;

                return new Vector2(x1, y1);
            }
        }

        public Vector2 SecondCtrlPoint
        {
            get
            {
                var x2 = ControlPoint.X + (End.X - ControlPoint.X) / 3;
                var y2 = ControlPoint.Y + (End.Y - ControlPoint.Y) / 3;

                return new Vector2(x2, y2);
            }
        }

        public SvgQuadraticCurveSegment(Vector2 start, Vector2 controlPoint, Vector2 end)
        {
            Start = start;
            ControlPoint = controlPoint;
            End = end;
        }


        public override string ToString()
        {
            return "Q" + ToSvgString(ControlPoint) + " " + ToSvgString(End);
        }
    }
}