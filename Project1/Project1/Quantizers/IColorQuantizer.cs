using System;
using System.Collections.Generic;
using System.Drawing;

namespace Project1.Quantizers
{
    public interface IColorQuantizer
    {
        void AddColor(Color color);

        List<Color> GetPalette(Int32 colorCount);

        Int32 GetPaletteIndex(Color color);

        Int32 GetColorCount();

        void Clear();
    }
}

//https://www.codeproject.com/Articles/66341/A-Simple-Yet-Quite-Powerful-Palette-Quantizer-in-C