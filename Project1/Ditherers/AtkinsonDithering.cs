namespace Project1.Ditherers
{
    class AtkinsonDithering : DitheringBase
    {
        public AtkinsonDithering(FindColor colorfunc) : base(colorfunc)
        {

        }

        override protected void PushError(int x, int y, short[] quantError)
        {
            int xMinusOne = x - 1;
            int xPlusOne = x + 1;
            int xPlusTwo = x + 2;
            int yPlusOne = y + 1;
            int yPlusTwo = y + 2;

            float multiplier = 1.0f / 8.0f; // Atkinson Dithering has same multiplier for every item

            int currentRow = y;
            if (this.IsValidCoordinate(xPlusOne, currentRow))
            {
                this.ModifyImageWithErrorAndMultiplier(xPlusOne, currentRow, quantError, multiplier);
            }

            if (this.IsValidCoordinate(xPlusTwo, currentRow))
            {
                this.ModifyImageWithErrorAndMultiplier(xPlusTwo, currentRow, quantError, multiplier);
            }

            currentRow = yPlusOne;
            if (this.IsValidCoordinate(xMinusOne, currentRow))
            {
                this.ModifyImageWithErrorAndMultiplier(xMinusOne, currentRow, quantError, multiplier);
            }

            if (this.IsValidCoordinate(x, currentRow))
            {
                this.ModifyImageWithErrorAndMultiplier(x, currentRow, quantError, multiplier);
            }

            if (this.IsValidCoordinate(xPlusOne, currentRow))
            {
                this.ModifyImageWithErrorAndMultiplier(xPlusOne, currentRow, quantError, multiplier);
            }

            currentRow = yPlusTwo;
            if (this.IsValidCoordinate(x, currentRow))
            {
                this.ModifyImageWithErrorAndMultiplier(x, currentRow, quantError, multiplier);
            }
        }
    }
}

//https://github.com/mcraiha/CSharp-Dithering