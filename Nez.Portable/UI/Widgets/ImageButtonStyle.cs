namespace Nez.UI
{
    public class ImageButtonStyle : ButtonStyle
    {
        /** Optional. */
        public IDrawable ImageUp, ImageDown, ImageOver, ImageChecked, ImageCheckedOver, ImageDisabled;


        public ImageButtonStyle()
        { }


        public ImageButtonStyle(IDrawable up, IDrawable down, IDrawable checkked, IDrawable imageUp,
            IDrawable imageDown, IDrawable imageChecked) : base(up, down, checkked)
        {
            ImageUp = imageUp;
            ImageDown = imageDown;
            ImageChecked = imageChecked;
        }


        public new ImageButtonStyle Clone()
        {
            return new ImageButtonStyle
            {
                Up = Up,
                Down = Down,
                Over = Over,
                Checked = Checked,
                CheckedOver = CheckedOver,
                Disabled = Disabled,

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