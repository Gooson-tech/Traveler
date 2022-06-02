using Microsoft.Xna.Framework;
using Nez.BitmapFonts;

namespace Nez.UI
{
    /// <summary>
    /// The style for a text button
    /// </summary>
    public class TextButtonStyle : ButtonStyle
    {
        public BitmapFont Font;

        /** Optional. */
        public Color FontColor = Color.White;
        public Color? DownFontColor, OverFontColor, CheckedFontColor, CheckedOverFontColor, DisabledFontColor;


        public TextButtonStyle()
        {
            Font = Graphics.Instance.BitmapFont;
        }


        public TextButtonStyle(IDrawable up, IDrawable down, IDrawable over, BitmapFont font) : base(up, down, over)
        {
            Font = font ?? Graphics.Instance.BitmapFont;
        }


        public TextButtonStyle(IDrawable up, IDrawable down, IDrawable over) : this(up, down, over,
            Graphics.Instance.BitmapFont)
        {
        }


        public new static TextButtonStyle Create(Color upColor, Color downColor, Color overColor)
        {
            return new TextButtonStyle
            {
                Up = new PrimitiveDrawable(upColor),
                Down = new PrimitiveDrawable(downColor),
                Over = new PrimitiveDrawable(overColor)
            };
        }


        public new TextButtonStyle Clone()
        {
            return new TextButtonStyle
            {
                Up = Up,
                Down = Down,
                Over = Over,
                Checked = Checked,
                CheckedOver = CheckedOver,
                Disabled = Disabled,

                Font = Font,
                FontColor = FontColor,
                DownFontColor = DownFontColor,
                OverFontColor = OverFontColor,
                CheckedFontColor = CheckedFontColor,
                CheckedOverFontColor = CheckedOverFontColor,
                DisabledFontColor = DisabledFontColor
            };
        }
    }
}