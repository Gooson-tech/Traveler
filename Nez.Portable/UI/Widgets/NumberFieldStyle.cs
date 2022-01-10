using Microsoft.Xna.Framework;
using Nez.BitmapFonts;

namespace Nez.UI
{
    public class NumberFieldStyle : TextFieldStyle
    {
        public IDrawable ImageUp, ImageDown, ImageOver, ImageChecked, ImageCheckedOver, ImageDisabled;

        public TextButtonStyle DecreaseButtonStyle;
        public TextButtonStyle IncreaseButtonStyle;

        public NumberFieldStyle()
        {
            Font = Graphics.Instance.BitmapFont;
        }


        public NumberFieldStyle(BitmapFont font, Color fontColor, IDrawable cursor, IDrawable selection, IDrawable background, TextButtonStyle decreaseButtonStyle, TextButtonStyle increaseButtonStyle) : base(font, fontColor, cursor, selection, background)
        {
            this.DecreaseButtonStyle = decreaseButtonStyle;
            this.IncreaseButtonStyle = increaseButtonStyle;
        }


        public new TextFieldStyle Clone()
        {
            return new TextFieldStyle
            {
                Font = Font,
                FontColor = FontColor,
                FocusedFontColor = FocusedFontColor,
                DisabledFontColor = DisabledFontColor,
                Background = Background,
                FocusedBackground = FocusedBackground,
                DisabledBackground = DisabledBackground,
                Cursor = Cursor,
                Selection = Selection,
                MessageFont = MessageFont,
                MessageFontColor = MessageFontColor
            };
        }
    }
}