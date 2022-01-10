using System.Collections.Generic;

namespace Nez.Tiled
{
    public class TmxTerrain : ITmxElement
    {
        public string Name { get; set; }
        public int Tile;
        public Dictionary<string, string> Properties;
    }
}