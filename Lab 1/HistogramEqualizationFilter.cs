using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    // Ядро фильтра не константное, поэтому
    // от Filters, а не от MatrixFilter
    class HistogramEqualizationFilter : Filters
    {
        int minBrightness = 255;
        int maxBrightness = 0;

        public void findMinMaxBrightness(Bitmap sourceImage)
        {
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color pixelColor = sourceImage.GetPixel(i, j);
                    int brightness = (int)
                        (0.299 * pixelColor.R +
                         0.587 * pixelColor.G +
                         0.114 * pixelColor.B);

                    minBrightness = Math.Min(minBrightness, brightness);
                    maxBrightness = Math.Max(maxBrightness, brightness);
                }
            }
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int brightness = (int)
                (0.299 * sourceColor.R +
                 0.587 * sourceColor.G +
                 0.114 * sourceColor.B);

            brightness = (brightness - minBrightness) * 
                         (255-0) / (maxBrightness - minBrightness);

            return Color.FromArgb(brightness, brightness, brightness);
        }
    }
}
