using Nez.BitmapFonts;

namespace Nez.UI
{
    public class ImageTextButtonStyle : TextButtonStyle
    {
        /** Optional. */
        public IDrawable ImageUp, ImageDown, ImageOver, ImageChecked, ImageCheckedOver, ImageDisabled;


        public ImageTextButtonStyle()
        {
            Font = Graphics.Instance.BitmapFont;
        }


        public ImageTextButtonStyle(IDrawable up, IDrawable down, IDrawable over, BitmapFont font) : base(up, down,
            over, font)
        {
        }


        public new ImageTextButtonStyle Clone()
        {
            return new ImageTextButtonStyle
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
                DisabledFontColor = DisabledFontColor,

                ImageUp = ImageUp,
                ImageDown = ImageDown,
                ImageOver = ImageOver,
                ImageChecked = ImageChecked,
                ImageCheckedOver = ImageCheckedOver,
                ImageDisabled = ImageDisabled
            };
        }
    }
}