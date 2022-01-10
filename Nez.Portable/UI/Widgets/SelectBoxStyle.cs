using Microsoft.Xna.Framework;
using Nez.BitmapFonts;

namespace Nez.UI
{
    public class SelectBoxStyle
    {
        public BitmapFont Font;

        public Color FontColor = Color.White;

        /** Optional */
        public Color DisabledFontColor;

        /** Optional */
        public IDrawable Background;
        public ScrollPaneStyle ScrollStyle;

        public ListBoxStyle ListStyle;

        /** Optional */
        public IDrawable BackgroundOver, BackgroundOpen, BackgroundDisabled;


        public SelectBoxStyle()
        {
            Font = Graphics.Instance.BitmapFont;
        }

        public SelectBoxStyle(BitmapFont font, Color fontColor, IDrawable background, ScrollPaneStyle scrollStyle,
            ListBoxStyle listStyle)
        {
            Font = font;
            FontColor = fontColor;
            Background = background;
            ScrollStyle = scrollStyle;
            ListStyle = listStyle;
        }
    }
}