using System;
using System.Collections.Generic;
using System.Drawing;

namespace Project1.Helpers
{
    public class QuantizationHelper
    {
        private static readonly Color BackgroundColor;
        private static readonly Double[] Factors;

        internal static Color ConvertAlpha(Color color)
        {
            Color result = color;

            if (color.A < 255)
            {
                Double colorFactor = Factors[color.A];
                Double backgroundFactor = Factors[255 - color.A];
                int red = (int) (color.R*colorFactor + BackgroundColor.R*backgroundFactor);
                int green = (int) (color.G*colorFactor + BackgroundColor.G*backgroundFactor);
                int blue = (int) (color.B*colorFactor + BackgroundColor.B*backgroundFactor);
                result = Color.FromArgb(255, red, green, blue);
            }

            return result;
        }

        internal static int GetNearestColor(Color color, IList<Color> palette)
        {
            int bestIndex = 0;
            int leastDifference = int.MaxValue;

            for (int i = 0; i < palette.Count; i++)
            {
                Color targetColor = palette[i];

                int deltaA = color.A - targetColor.A;
                int deltaR = color.R - targetColor.R;
                int deltaG = color.G - targetColor.G;
                int deltaB = color.B - targetColor.B;

                int factorA = deltaA * deltaA;
                int factorR = deltaR * deltaR;
                int factorG = deltaG * deltaG;
                int factorB = deltaB * deltaB;

                int difference = factorA + factorR + factorG + factorB;

                if (difference == 0)
                {
                    bestIndex = i;
                    break;
                }

                if (difference < leastDifference)
                {
                    leastDifference = difference;
                    bestIndex = i;
                }
            }

            return bestIndex;
        }
    }
}

//https://www.codeproject.com/Articles/66341/A-Simple-Yet-Quite-Powerful-Palette-Quantizer-in-C