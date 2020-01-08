using System;
using System.Drawing;
using Project1.Ditherers;

namespace Project1
{
    class Ditherhelper
    {
        public static Bitmap Dithering(Image input)
        {
            Bitmap b = new Bitmap(input);
            return DitherCalculate(new AtkinsonDithering(TrueColorToWebSafeColor), b);
        }

        public static Bitmap DitherCalculate(DitheringBase method, Bitmap input)
        {
            Bitmap dithered = method.DoDithering(input);
            return dithered;
        }

        private static Color TrueColorToWebSafeColor(Color inputColor)
        {
            Color returnColor = Color.FromArgb((byte)Math.Round(inputColor.R / 51.0) * 51,
                                                (byte)Math.Round(inputColor.G / 51.0) * 51,
                                                (byte)Math.Round(inputColor.B / 51.0) * 51);
            return returnColor;
        }
    }
}

//https://github.com/mcraiha/CSharp-Dithering
