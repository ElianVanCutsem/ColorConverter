using System;
using System.Drawing;

namespace Project1.Helpers
{
    class ColorDistance
    {
        public static double GetColorDistance(Image SourceImage, Image Result)
        {
            int R1, R2, G1, G2, B1, B2;

            int counter = 0;
            double result = 0;

            Bitmap Original = new Bitmap(SourceImage);
            Bitmap Edit = new Bitmap(Result);

            for (int i = 0; i < Original.Width; i++)
            {
                for (int j = 0; j < Original.Height; j++)
                {
                    Color PixelColor = Original.GetPixel(i, j);
                    R1 = PixelColor.R;
                    G1 = PixelColor.G;
                    B1 = PixelColor.B;

                    Color PixelColor2 = Edit.GetPixel(i, j);
                    R2 = PixelColor2.R;
                    G2 = PixelColor2.G;
                    B2 = PixelColor2.B;
                    counter++;

                    result += Math.Sqrt(CalculatePower(R2 - R1, 2) + CalculatePower(G2 - G1, 2) + CalculatePower(B2 - B1, 2));
                }
            }

            result /= counter;
            return result;
        }

        private static double CalculatePower(double number, int powerOf)
        {
            for (int i = powerOf; i > 1; i--)
                number *= number;
            return number;
        }
    }
}
