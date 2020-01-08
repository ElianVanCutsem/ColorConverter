using System;
using System.Collections.Generic;
using System.Drawing;
using Project1.Helpers;

namespace Project1.Quantizers.Uniform
{
    public class UniformQuantizer : IColorQuantizer
    {
        private readonly UniformColorSlot[] redSlots;
        private readonly UniformColorSlot[] greenSlots;
        private readonly UniformColorSlot[] blueSlots;

        public UniformQuantizer()
        {
            redSlots = new UniformColorSlot[8];
            greenSlots = new UniformColorSlot[8];
            blueSlots = new UniformColorSlot[4];
        }

        #region << IColorQuantizer >>
        public void AddColor(Color color)
        {
            color = QuantizationHelper.ConvertAlpha(color);

            int redIndex = color.R >> 5;
            int greenIndex = color.G >> 5;
            int blueIndex = color.B >> 6;

            redSlots[redIndex].AddValue(color.R);
            greenSlots[greenIndex].AddValue(color.G);
            blueSlots[blueIndex].AddValue(color.B);
        }

        public List<Color> GetPalette(Int32 colorCount)
        {
            List<Color> result = new List<Color>();

            foreach (UniformColorSlot redSlot in redSlots)
            foreach (UniformColorSlot greenSlot in greenSlots)
            foreach (UniformColorSlot blueSlot in blueSlots)
            {
                Int32 red = redSlot.GetAverage();
                Int32 green = greenSlot.GetAverage();
                Int32 blue = blueSlot.GetAverage();

                Color color = Color.FromArgb(255, red, green, blue);
                result.Add(color);
            }

            return result;
        }

        public int GetPaletteIndex(Color color)
        {
            color = QuantizationHelper.ConvertAlpha(color);
            int redIndex = color.R >> 5;
            int greenIndex = color.G >> 5;
            int blueIndex = color.B >> 6;
            return (redIndex << 5) + (greenIndex << 2) + blueIndex;
        }

        public int GetColorCount()
        {
            // returns the count in red slots, as it should be the same in red, blue or green
            return 256;
        }

        public void Clear()
        {
            Array.Clear(redSlots, 0, 8);
            Array.Clear(greenSlots, 0, 8);
            Array.Clear(blueSlots, 0, 4);
        }

        #endregion
    }
}

////https://www.codeproject.com/Articles/66341/A-Simple-Yet-Quite-Powerful-Palette-Quantizer-in-C