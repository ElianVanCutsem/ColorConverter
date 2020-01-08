using System;

namespace Project1.Quantizers.Uniform
{
    internal struct UniformColorSlot
    {
        private Int32 value;
        private Int32 pixelCount;

        public void AddValue(Int32 component)
        {
            value += component;
            pixelCount++;
        }

        public Int32 GetAverage()
        {
            Int32 result = 0;

            if (pixelCount > 0)
            {
                result = pixelCount == 1 ? value : value/pixelCount;
            }

            return result;
        }
    }
}

//https://www.codeproject.com/Articles/66341/A-Simple-Yet-Quite-Powerful-Palette-Quantizer-in-C