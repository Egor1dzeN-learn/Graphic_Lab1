using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double intensity = ((sourceColor.R * 0.299) +
                                (sourceColor.G * 0.587) +
                                (sourceColor.B * 0.144));
            int newColor = Clamp((int)intensity, 0, 255);
            return Color.FromArgb(newColor, newColor, newColor);
        }
    }
}
