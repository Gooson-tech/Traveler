﻿using System;

namespace Nez
{
    /// <summary>
    /// displays a tooltip when hovering over the label of any inspectable elements
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method)]
    public class TooltipAttribute : InspectableAttribute
    {
        public string Tooltip;

        public TooltipAttribute(string tooltip)
        {
            Tooltip = tooltip;
        }
    }
}