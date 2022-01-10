using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Nez.Tiled
{
    public class TmxObject : ITmxElement
    {
        public int Id;
        public string Name { get; set; }
        public TmxObjectType ObjectType;
        public string Type;
        public float X;
        public float Y;
        public float Width;
        public float Height;
        public float Rotation;
        public TmxLayerTile Tile;
        public bool Visible;
        public TmxText Text;

        public Vector2[] Points;
        public Dictionary<string, string> Properties;
    }
}