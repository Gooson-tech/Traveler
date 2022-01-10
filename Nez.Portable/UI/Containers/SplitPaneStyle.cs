namespace Nez.UI
{
    public class SplitPaneStyle
    {
        public IDrawable Handle;


        public SplitPaneStyle()
        { }


        public SplitPaneStyle(IDrawable handle)
        {
            Handle = handle;
        }


        public SplitPaneStyle Clone()
        {
            return new SplitPaneStyle
            {
                Handle = Handle
            };
        }
    }
}