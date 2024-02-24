using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class MedianFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int kernelSize = 3; // 3x3
            int radius = kernelSize / 2;

            int[] redValues = new int[kernelSize * kernelSize];
            int[] greenValues = new int[kernelSize * kernelSize];
            int[] blueValues = new int[kernelSize * kernelSize];

            int index = 0;

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    int newX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int newY = Clamp(y + i, 0, sourceImage.Height - 1);

                    Color neighborColor = sourceImage.GetPixel(newX, newY);

                    redValues[index] = neighborColor.R;
                    greenValues[index] = neighborColor.G;
                    blueValues[index] = neighborColor.B;

                    index++;
                }
            }

            Array.Sort(redValues);
            Array.Sort(greenValues);
            Array.Sort(blueValues);

            int medianIndex = kernelSize * kernelSize / 2;

            int medianRed = redValues[medianIndex];
            int medianGreen = greenValues[medianIndex];
            int medianBlue = blueValues[medianIndex];

            return Color.FromArgb(medianRed, medianGreen, medianBlue);
        }
    }
}
