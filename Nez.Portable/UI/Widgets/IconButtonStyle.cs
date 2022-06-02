namespace Nez.UI
{
    public class IconButtonStyle : ImageButtonStyle
    {
        public IDrawable Icon;
        public int PadLeft, PadRight, PadTop, PadBottom;

        public IconButtonStyle()
        { }


        public IconButtonStyle(IDrawable icon, IDrawable up, IDrawable down, IDrawable checkked, IDrawable imageUp, IDrawable imageDown, IDrawable imageChecked) : base(up, down, checkked, imageUp, imageDown, imageChecked)
        {
            this.Icon = icon;
        }


        public new IconButtonStyle Clone()
        {
            return new IconButtonStyle
            {
                Icon = Icon,
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