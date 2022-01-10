using Microsoft.Xna.Framework;

namespace Nez.UI
{
    /// <summary>
    /// The style for a progress bar
    /// </summary>
    public class ProgressBarStyle
    {
        /// <summary>
        /// The progress bar background, stretched only in one direction. Optional.
        /// </summary>
        public IDrawable Background;

        /// <summary>
        /// Optional
        /// </summary>
        public IDrawable DisabledBackground;

        /// <summary>
        /// Optional, centered on the background.
        /// </summary>
        public IDrawable Knob, DisabledKnob;

        /// <summary>
        /// Optional
        /// </summary>
        public IDrawable KnobBefore, KnobAfter, DisabledKnobBefore, DisabledKnobAfter;


        public ProgressBarStyle()
        {
        }


        public ProgressBarStyle(IDrawable background, IDrawable knob)
        {
            Background = background;
            Knob = knob;
        }


        public static ProgressBarStyle Create(Color knobBeforeColor, Color knobAfterColor)
        {
            var knobBefore = new PrimitiveDrawable(knobBeforeColor);
            knobBefore.MinHeight = 10;

            var knobAfter = new PrimitiveDrawable(knobAfterColor);
            knobAfter.MinWidth = knobAfter.MinHeight = 10;

            return new ProgressBarStyle
            {
                KnobBefore = knobBefore,
                KnobAfter = knobAfter
            };
        }


        public static ProgressBarStyle CreateWithKnob(Color backgroundColor, Color knobColor)
        {
            var background = new PrimitiveDrawable(backgroundColor);
            background.MinWidth = background.MinHeight = 10;

            var knob = new PrimitiveDrawable(knobColor);
            knob.MinWidth = knob.MinHeight = 20;

            return new ProgressBarStyle
            {
                Background = background,
                Knob = knob
            };
        }


        public ProgressBarStyle Clone()
        {
            return new ProgressBarStyle
            {
                Background = Background,
                DisabledBackground = DisabledBackground,
                Knob = Knob,
                DisabledKnob = DisabledKnob,
                KnobBefore = KnobBefore,
                KnobAfter = KnobAfter,
                DisabledKnobBefore = DisabledKnobBefore,
                DisabledKnobAfter = DisabledKnobAfter
            };
        }
    }
}