using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nez
{
    struct CompiledTextElement : ICompiledElement
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }

        readonly FormatInstruction _formatInstruction;
        readonly string _text;


        public CompiledTextElement(string text, Vector2 position, FormatInstruction formatInstruction)
        {
            _text = text;
            Position = position;
            _formatInstruction = formatInstruction;
            Size = formatInstruction.Font.MeasureString(text) * formatInstruction.Scale;
        }


        public void Render(Batcher batcher, Vector2 offset)
        {
            var origin = new Vector2(0, Size.Y / (2 * _formatInstruction.Scale.Y));
            batcher.DrawString(_formatInstruction.Font, _text, offset + Position, _formatInstruction.Color, 0,
                origin, _formatInstruction.Scale, SpriteEffects.None, 0);
        }
    }
}