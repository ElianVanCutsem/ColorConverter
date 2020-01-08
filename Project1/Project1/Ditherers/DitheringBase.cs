using System;
using System.Drawing;

namespace Project1.Ditherers
{
    public delegate Color FindColor(Color original);

    public abstract class DitheringBase
    {

        protected Bitmap currentBitmap = null;

        protected int width;
        protected int height;

        protected string methodLongName = "";
        protected string fileNameAddition = "";

        protected FindColor colorFunction = null;

        public DitheringBase(FindColor colorfunc)
        {
            this.colorFunction = colorfunc;
        }

        public Bitmap DoDithering(Bitmap input)
        {
            this.width = input.Width;
            this.height = input.Height;

            this.currentBitmap = new Bitmap(input);

            Color originalPixel = Color.White; // Default value isn't used
            Color newPixel = Color.White; // Default value isn't used
            short[] quantError = null; // Default values aren't used

            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    originalPixel = this.currentBitmap.GetPixel(x, y);
                    newPixel = this.colorFunction(originalPixel);

                    this.currentBitmap.SetPixel(x, y, newPixel);

                    quantError = GetQuantError(originalPixel, newPixel);

                    this.PushError(x, y, quantError);
                }
            }

            return this.currentBitmap;
        }

        protected short[] GetQuantError(Color originalPixel, Color newPixel)
        {
            short[] returnValue = new short[4];

            returnValue[0] = (short)(originalPixel.R - newPixel.R);
            returnValue[1] = (short)(originalPixel.G - newPixel.G);
            returnValue[2] = (short)(originalPixel.B - newPixel.B);
            returnValue[3] = (short)(originalPixel.A - newPixel.A);

            return returnValue;
        }

        protected bool IsValidCoordinate(int x, int y)
        {
            return (0 <= x && x < this.width && 0 <= y && y < this.height);
        }

        protected abstract void PushError(int x, int y, short[] quantError);

        public void ModifyImageWithErrorAndMultiplier(int x, int y, short[] quantError, float multiplier)
        {
            Color oldColor = Color.White; // Default color isn't used
            oldColor = this.currentBitmap.GetPixel(x, y);

            Color newColor = Color.FromArgb(
                                GetLimitedValue(oldColor.R, (int)Math.Round(quantError[0] * multiplier)),
                                GetLimitedValue(oldColor.G, (int)Math.Round(quantError[1] * multiplier)),
                                GetLimitedValue(oldColor.B, (int)Math.Round(quantError[2] * multiplier)));

                this.currentBitmap.SetPixel(x, y, newColor);
        }

        private static byte GetLimitedValue(byte original, int error)
        {
            int newValue = original + error;
            return (byte)Clamp(newValue, byte.MinValue, byte.MaxValue);
        }

        private static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }
    }
}

//https://github.com/mcraiha/CSharp-Dithering