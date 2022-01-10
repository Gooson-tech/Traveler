using Microsoft.Xna.Framework;

namespace Nez
{
    struct FormatInstruction
    {
        public readonly Color Color;
        public readonly IFont Font;
        public readonly Vector2 Scale;


        public FormatInstruction(IFont font, Color color, Vector2 scale)
        {
            Font = font;
            Color = color;
            Scale = scale;
        }
    }
}