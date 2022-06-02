using Microsoft.Xna.Framework;
using Nez.BitmapFonts;

namespace Nez.UI
{
    public class TextFieldStyle
    {
        public BitmapFont Font;

        public Color FontColor = Color.White;

        /** Optional. */
        public Color? FocusedFontColor, DisabledFontColor;

        /** Optional. */
        public IDrawable Background, FocusedBackground, DisabledBackground, Cursor, Selection;

        /** Optional. */
        public BitmapFont MessageFont;

        /** Optional. */
        public Color? MessageFontColor;


        public TextFieldStyle()
        {
            Font = Graphics.Instance.BitmapFont;
        }


        public TextFieldStyle(BitmapFont font, Color fontColor, IDrawable cursor, IDrawable selection,
            IDrawable background)
        {
            Background = background;
            Cursor = cursor;
            Font = font ?? Graphics.Instance.BitmapFont;
            FontColor = fontColor;
            Selection = selection;
        }


        public static TextFieldStyle Create(Color fontColor, Color cursorColor, Color selectionColor,
            Color backgroundColor)
        {
            var cursor = new PrimitiveDrawable(cursorColor);
            cursor.MinWidth = 1;
            cursor.LeftWidth = 4;

            var background = new PrimitiveDrawable(backgroundColor);
            background.LeftWidth = background.RightWidth = 10f;
            background.BottomHeight = background.TopHeight = 5f;

            return new TextFieldStyle
            {
                FontColor = fontColor,
                Cursor = cursor,
                Selection = new PrimitiveDrawable(selectionColor),
                Background = background
            };
        }


        public TextFieldStyle Clone()
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