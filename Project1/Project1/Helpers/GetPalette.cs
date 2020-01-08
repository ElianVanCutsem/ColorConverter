using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Helpers
{
    class GetPalette
    {
        public static Bitmap GetPaletteBitmap(List<Color> color)
        {
            Bitmap b = new Bitmap(16, 16); // 16 x 16 = 256
            for (int i = 0; i < b.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    b.SetPixel(i, j, color[i]);
                }
            }
            
            return b;
        }
    }
}
