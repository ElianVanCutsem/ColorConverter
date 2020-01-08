using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Project1.Helpers;

namespace Project1.Quantizers.Popularity
{
    public class PopularityQuantizer : IColorQuantizer
    {
        private readonly List<Color> palette;
        private readonly Dictionary<Color, int> cache;
        private readonly Dictionary<int, PopularityColorSlot> colorMap;

        public PopularityQuantizer()
        {
            palette = new List<Color>();
            cache = new Dictionary<Color, int>();
            colorMap = new Dictionary<int, PopularityColorSlot>();
        }

        #region | Methods |

        private static int GetColorIndex(Color color)
        {
            int redIndex = color.R >> 2;
            int greenIndex = color.G >> 2;
            int blueIndex = color.B >> 2;

            return (redIndex << 12) + (greenIndex << 6) + blueIndex;
        }

        #endregion

        #region << IColorQuantizer >>

        public void AddColor(Color color)
        {
            PopularityColorSlot slot;
            color = QuantizationHelper.ConvertAlpha(color);
            int index = GetColorIndex(color);

            if (colorMap.TryGetValue(index, out slot))
            {
                slot.AddValue(color);
            }
            else
            {
                colorMap[index] = new PopularityColorSlot(color);
            }
        }

        public List<Color> GetPalette(int colorCount)
        {
            Random random = new Random();

            IEnumerable<Color> colors = colorMap.
                 OrderBy(entry => random.NextDouble()).
                 OrderByDescending(entry => entry.Value.PixelCount).
                 Take(colorCount).
                 Select(entry => entry.Value.GetAverage());

            palette.Clear();
            palette.AddRange(colors);
            return palette;
        }

        public int GetPaletteIndex(Color color)
        {
            int result;
            color = QuantizationHelper.ConvertAlpha(color);

            if (!cache.TryGetValue(color, out result))
            {
                result = QuantizationHelper.GetNearestColor(color, palette);
                cache[color] = result;
            }

            return result; 
        }

        public int GetColorCount()
        {
            return colorMap.Count;
        }

        public void Clear()
        {
            cache.Clear();
            palette.Clear();
            colorMap.Clear();
        }

        #endregion
    }
}

//https://www.codeproject.com/Articles/66341/A-Simple-Yet-Quite-Powerful-Palette-Quantizer-in-C