using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class BrightnessFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            int increaseAmount = 50;
            int newR = Clamp(sourceColor.R + increaseAmount, 0, 255);
            int newG = Clamp(sourceColor.G + increaseAmount, 0, 255);
            int newB = Clamp(sourceColor.B + increaseAmount, 0, 255);

            return Color.FromArgb(newR, newG, newB);
        }
    }
}
