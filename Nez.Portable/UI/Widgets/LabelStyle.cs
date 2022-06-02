using Microsoft.Xna.Framework;
using Nez.BitmapFonts;

namespace Nez.UI
{
    /// <summary>
    /// the style for a label
    /// </summary>
    public class LabelStyle
    {
        public Color FontColor = Color.White;
        public BitmapFont Font;
        public IDrawable Background;


        public LabelStyle()
        {
            Font = Graphics.Instance.BitmapFont;
        }


        public LabelStyle(BitmapFont font, Color fontColor)
        {
            Font = font ?? Graphics.Instance.BitmapFont;
            FontColor = fontColor;
        }


        public LabelStyle(Color fontColor) : this(null, fontColor)
        { }


        public LabelStyle Clone()
        {
            return new LabelStyle
            {
                FontColor = FontColor,
                Font = Font,
                Background = Background
            };
        }
    }
}