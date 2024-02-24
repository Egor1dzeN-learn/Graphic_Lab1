using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            float intensity = ((sourceColor.R * 0.299f) +
                                (sourceColor.G * 0.587f) +
                                (sourceColor.B * 0.144f));
            float k = 15;
            int newR = Clamp((int)(intensity + 2 * k), 0, 255);
            int newG = Clamp((int)(intensity + 0.5 * k), 0, 255);
            int newB = Clamp((int)(intensity - 1 * k), 0, 255);

            return Color.FromArgb(newR, newG, newB);
        }
    }
}
