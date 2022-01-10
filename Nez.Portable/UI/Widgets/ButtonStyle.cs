using Microsoft.Xna.Framework;

namespace Nez.UI
{
    /// <summary>
    /// The style for a button
    /// </summary>
    public class ButtonStyle
    {
        /** Optional. */
        public IDrawable Up, Down, Over, Checked, CheckedOver, Disabled;

        /** Optional. offsets children (labels for example). */
        public float PressedOffsetX, PressedOffsetY, UnpressedOffsetX, UnpressedOffsetY, CheckedOffsetX, CheckedOffsetY;


        public ButtonStyle()
        { }


        public ButtonStyle(IDrawable up, IDrawable down, IDrawable over)
        {
            Up = up;
            Down = down;
            Over = over;
        }


        public static ButtonStyle Create(Color upColor, Color downColor, Color overColor)
        {
            return new ButtonStyle
            {
                Up = new PrimitiveDrawable(upColor),
                Down = new PrimitiveDrawable(downColor),
                Over = new PrimitiveDrawable(overColor)
            };
        }


        public ButtonStyle Clone()
        {
            return new ButtonStyle
            {
                Up = Up,
                Down = Down,
                Over = Over,
                Checked = Checked,
                CheckedOver = CheckedOver,
                Disabled = Disabled
            };
        }
    }
}