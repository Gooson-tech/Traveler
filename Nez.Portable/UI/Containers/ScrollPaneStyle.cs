namespace Nez.UI
{
    public class ScrollPaneStyle
    {
        /** Optional. */
        public IDrawable Background, Corner;

        /** Optional. */
        public IDrawable HScroll, HScrollKnob;

        /** Optional. */
        public IDrawable VScroll, VScrollKnob;


        public ScrollPaneStyle()
        {
        }


        public ScrollPaneStyle(IDrawable background, IDrawable hScroll, IDrawable hScrollKnob, IDrawable vScroll,
            IDrawable vScrollKnob)
        {
            Background = background;
            HScroll = hScroll;
            HScrollKnob = hScrollKnob;
            VScroll = vScroll;
            VScrollKnob = vScrollKnob;
        }


        public ScrollPaneStyle(ScrollPaneStyle style)
        {
            Background = style.Background;
            HScroll = style.HScroll;
            HScrollKnob = style.HScrollKnob;
            VScroll = style.VScroll;
            VScrollKnob = style.VScrollKnob;
        }


        public ScrollPaneStyle Clone()
        {
            return new ScrollPaneStyle
            {
                Background = Background,
                Corner = Corner,
                HScroll = HScroll,
                HScrollKnob = HScrollKnob,
                VScroll = VScroll,
                VScrollKnob = VScrollKnob
            };
        }
    }
}