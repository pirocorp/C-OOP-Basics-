﻿namespace Document_System.Elements.TextElements.FontElements
{
    using System;

    [Flags]
    public enum FontStyle
    {
        Normal = 0,
        Bold = 1,
        Italic = 2,
        BoldItalic = Bold | Italic
    }
}