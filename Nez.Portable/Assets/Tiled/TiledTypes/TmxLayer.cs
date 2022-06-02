using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Nez.Tiled
{
	public partial class TmxLayer : ITmxLayer
	{
		public TmxMap Map;
		public string Name { get; set; }
		public float Opacity { get; set; }
		public bool Visible { get; set; }
		public float OffsetX { get; set; }
		public float OffsetY { get; set; }
		public Vector2 Offset => new Vector2(OffsetX, OffsetY);
		public float ParallaxFactorX { get; set; }
		public float ParallaxFactorY { get; set; }
		public Vector2 ParallaxFactor => new Vector2(ParallaxFactorX, ParallaxFactorY);

		public Dictionary<string, string> Properties { get; set; }

		/// <summary>
		/// width in tiles for this layer. Always the same as the map width for fixed-size maps.
		/// </summary>
		public int Width;

		/// <summary>
		/// height in tiles for this layer. Always the same as the map height for fixed-size maps.
		/// </summary>
		public int Height;
		public TmxLayerTile[] Tiles;

		/// <summary>
		/// returns the TmxLayerTile with gid. This is a slow lookup so cache it!
		/// </summary>
		/// <param name="gid"></param>
		/// <returns></returns>
		public TmxLayerTile GetTileWithGid(int gid)
		{
			for (var i = 0; i < Tiles.Length; i++)
			{
				if (Tiles[i] != null && Tiles[i].Gid == gid)
					return Tiles[i];
			}
			return null;
		}
	}
}
