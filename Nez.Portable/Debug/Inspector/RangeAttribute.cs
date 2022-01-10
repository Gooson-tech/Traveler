using System;

namespace Nez
{
    /// <summary>
    /// Range attribute. Tells the inspector you want a slider to be displayed for a float/int
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class RangeAttribute : InspectableAttribute
    {
        public float MinValue;
        public float MaxValue;
        public float StepSize = 1;
        public bool UseDragVersion;


        public RangeAttribute(float minValue)
        {
            MinValue = minValue;

            // magic number! This is the highest number ImGui functions properly with for some reason.
            MaxValue = int.MaxValue - 100;
            UseDragVersion = true;
        }

        public RangeAttribute(float minValue, float maxValue, float stepSize)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            StepSize = stepSize;
        }

        public RangeAttribute(float minValue, float maxValue, bool useDragFloat)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            UseDragVersion = useDragFloat;
        }


        public RangeAttribute(float minValue, float maxValue) : this(minValue, maxValue, 0.1f)
        {
        }
    }
}