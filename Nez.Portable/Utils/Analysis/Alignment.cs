using System;

namespace Nez.Analysis
{
    /// <summary>
    /// Alignment for layout.
    /// </summary>
    [Flags]
    public enum Alignment
    {
        None = 0,

        // Horizontal layouts
        Left = 1,
        Right = 2,
        HorizontalCenter = 4,

        // Vertical layouts
        Top = 8,
        Bottom = 16,
        VerticalCenter = 32,

        // Combinations
        TopLeft = Top | Left,
        TopRight = Top | Right,
        TopCenter = Top | HorizontalCenter,

        BottomLeft = Bottom | Left,
        BottomRight = Bottom | Right,
        BottomCenter = Bottom | HorizontalCenter,

        CenterLeft = VerticalCenter | Left,
        CenterRight = VerticalCenter | Right,
        Center = VerticalCenter | HorizontalCenter
    }
}