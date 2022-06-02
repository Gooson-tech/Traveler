using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nez.Tiled
{
    public class TmxImage : IDisposable
    {
        public Texture2D Texture;
        public string Source;
        public string Format;
        public Stream Data;
        public Color Trans;
        public int Width;
        public int Height;

        public void Dispose()
        {
            if (Texture != null)
            {
                Texture.Dispose();
                Texture = null;
            }
        }
    }
}