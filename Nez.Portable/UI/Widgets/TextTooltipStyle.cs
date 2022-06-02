namespace Nez.UI
{
    public class TextTooltipStyle
    {
        public LabelStyle LabelStyle;

        /** Optional. */
        public IDrawable Background;


        public TextTooltipStyle()
        {
        }


        public TextTooltipStyle(LabelStyle label, IDrawable background)
        {
            LabelStyle = label;
            Background = background;
        }
    }
}