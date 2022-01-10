using Microsoft.Xna.Framework;
using Nez.BitmapFonts;

namespace Nez.UI
{
    public class WindowStyle
    {
        public BitmapFont TitleFont;

        /** Optional. */
        public IDrawable Background;

        /** Optional. */
        public Color TitleFontColor = Color.White;

        /** Optional. */
        public IDrawable StageBackground;


        public WindowStyle()
        {
            TitleFont = Graphics.Instance.BitmapFont;
        }


        public WindowStyle(BitmapFont titleFont, Color titleFontColor, IDrawable background)
        {
            TitleFont = titleFont ?? Graphics.Instance.BitmapFont;
            Background = background;
            TitleFontColor = titleFontColor;
        }


        public WindowStyle Clone()
        {
            return new WindowStyle
            {
                Background = Background,
                TitleFont = TitleFont,
                TitleFontColor = TitleFontColor,
                StageBackground = StageBackground
            };
        }
    }
}