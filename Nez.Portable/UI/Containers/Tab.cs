namespace Nez.UI
{
    public class Tab : Table
    {
        private TabStyle _style;
        public string TabName;

        public Tab(string name, TabStyle style)
        {
            TabName = name;
            _style = style;
            SetTouchable(Touchable.Enabled);
            Setup();
        }

        private void Setup()
        {
            SetBackground(_style.Background);
            SetFillParent(true);
            Top().Left();
        }
    }
}