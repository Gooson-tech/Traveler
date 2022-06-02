using Microsoft.Xna.Framework;
using Nez.BitmapFonts;

namespace Nez.UI
{
    /// <summary>
    /// The style for a select box
    /// </summary>
    public class CheckBoxStyle : TextButtonStyle
    {
        public IDrawable CheckboxOn, CheckboxOff;

        /** Optional. */
        public IDrawable CheckboxOver, CheckboxOnDisabled, CheckboxOffDisabled;


        public CheckBoxStyle()
        {
            Font = Graphics.Instance.BitmapFont;
        }


        public CheckBoxStyle(IDrawable checkboxOff, IDrawable checkboxOn, BitmapFont font, Color fontColor)
        {
            CheckboxOff = checkboxOff;
            CheckboxOn = checkboxOn;
            Font = font ?? Graphics.Instance.BitmapFont;
            FontColor = fontColor;
        }
    }
}