using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nez
{
    struct CompiledImageElement : ICompiledElement
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        readonly Color _color;
        readonly Texture2D _image;
        readonly Vector2 _scale;


        public CompiledImageElement(Texture2D image, Color color, Vector2 position, Vector2 scale)
        {
            _image = image;
            Position = position;
            _color = color;
            _scale = scale;
            Size = new Vector2(image.Width, image.Height) * scale;
        }


        public void Render(Batcher batcher, Vector2 offset)
        {
            var origin = new Vector2(0, _image.Height / 2f);
            batcher.Draw(_image, offset + Position, null, _color, 0, origin, _scale, SpriteEffects.None, 0);
        }
    }
}