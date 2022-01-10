using Microsoft.Xna.Framework;


namespace Nez.Svg
{
	/// <summary>
	/// base class for all of the different SVG path types. Note that arcs are not supported at this time.
	/// </summary>
	public abstract class SvgPathSegment
	{
		public Vector2 Start, End;


		protected SvgPathSegment()
		{
		}


		protected SvgPathSegment(Vector2 start, Vector2 end)
		{
			Start = start;
			End = end;
		}


		protected string ToSvgString(Vector2 point)
		{
			return string.Format("{0} {1}", point.X, point.Y);
		}
	}
}