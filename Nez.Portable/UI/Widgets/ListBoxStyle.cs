using Microsoft.Xna.Framework;
using Nez.BitmapFonts;

namespace Nez.UI
{
    public class ListBoxStyle
    {
        public BitmapFont Font;
        public Color FontColorSelected = Color.Black;
        public Color FontColorUnselected = Color.White;
        public Color FontColorHovered = Color.Black;

        public IDrawable Selection;

        /** Optional */
        public IDrawable HoverSelection;

        /** Optional */
        public IDrawable Background;


        public ListBoxStyle()
        {
            Font = Graphics.Instance.BitmapFont;
        }


        public ListBoxStyle(BitmapFont font, Color fontColorSelected, Color fontColorUnselected, IDrawable selection)
        {
            Font = font;
            FontColorSelected = fontColorSelected;
            FontColorUnselected = fontColorUnselected;
            Selection = selection;
        }


        public ListBoxStyle Clone()
        {
            return new ListBoxStyle
            {
                Font = Font,
                FontColorSelected = FontColorSelected,
                FontColorUnselected = FontColorUnselected,
                Selection = Selection,
                HoverSelection = HoverSelection,
                Background = Background
            };
        }
    }
}