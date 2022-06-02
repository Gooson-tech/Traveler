using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Nez.Tiled
{
	public class TmxObjectGroup : ITmxLayer
	{
		public TmxMap Map;
		public string Name { get; set; }
		public float Opacity { get; set; }
		public bool Visible { get; set; }
		public float OffsetX { get; set; }
		public float OffsetY { get; set; }
		public float ParallaxFactorX { get; set; }
		public float ParallaxFactorY { get; set; }

		public Color Color;
		public DrawOrderType DrawOrder;

		public TmxList<TmxObject> Objects;
		public Dictionary<string, string> Properties { get; set; }
	}
}
