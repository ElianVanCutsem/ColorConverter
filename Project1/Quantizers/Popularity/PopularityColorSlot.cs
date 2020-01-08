using System;
using System.Drawing;

namespace Project1.Quantizers.Popularity
{
    internal class PopularityColorSlot
    {
        private int red;
        private int green;
        private int blue;

        public int PixelCount { get; private set; }

        public PopularityColorSlot(Color color)
        {
            AddValue(color);
        }

        #region | Methods |

        public void AddValue(Color color)
        {
            red += color.R;
            green += color.G;
            blue += color.B;
            PixelCount++;
        }

        public Color GetAverage()
        {
            Color result;

            if (PixelCount == 1)
            {
                result = Color.FromArgb(255, red, green, blue);
            }
            else
            {
                result = Color.FromArgb(255, red/PixelCount, green/PixelCount, blue/PixelCount);
            }

            return result;
        }

        #endregion
    }
}

//https://www.codeproject.com/Articles/66341/A-Simple-Yet-Quite-Powerful-Palette-Quantizer-in-C