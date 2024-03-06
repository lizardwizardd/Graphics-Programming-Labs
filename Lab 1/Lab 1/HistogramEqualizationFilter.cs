using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Находит минимальную и максимальную интенсивность на изображении
// и корректирует цвета так, чтобы минимальная стала 0, и максимальная 255

namespace Lab_1
{
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
                        (pixelColor.R +
                         pixelColor.G +
                         pixelColor.B);

                    minBrightness = Math.Min(minBrightness, brightness);
                    maxBrightness = Math.Max(maxBrightness, brightness);
                }
            }
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int brightness = (int)
                (sourceColor.R +
                 sourceColor.G +
                 sourceColor.B);

            brightness = (brightness - minBrightness) * 
                         (255-0) / (maxBrightness - minBrightness);

            return Color.FromArgb(brightness, brightness, brightness);
        }
    }
}
