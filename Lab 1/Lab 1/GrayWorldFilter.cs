using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class GrayWorldFilter : Filters
    {
        float modifierR;
        float modifierG;
        float modifierB;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                Clamp((int)(sourceColor.R * modifierR), 0, 255),
                Clamp((int)(sourceColor.G * modifierG), 0, 255),
                Clamp((int)(sourceColor.B * modifierB), 0, 255));
            return resultColor;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            ulong sumR = 0;
            ulong sumG = 0;
            ulong sumB = 0;

            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            // Найти среднюю интенсивность каждого цвета
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    sumR += sourceImage.GetPixel(i, j).R;
                    sumG += sourceImage.GetPixel(i, j).G;
                    sumB += sourceImage.GetPixel(i, j).B;
                }

                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
            }

            ulong pixelCount = (ulong)(sourceImage.Width * sourceImage.Height);

            float avgR = sumR / pixelCount;
            float avgG = sumG / pixelCount;
            float avgB = sumB / pixelCount;
            float avgIntensity = (avgR + avgG + avgB) / 3;

            modifierR = (float)(avgIntensity / avgR);
            modifierG = (float)(avgIntensity / avgG);
            modifierB = (float)(avgIntensity / avgB);

            // Применение фильтра
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }

                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
            }

            return resultImage;
        }
    }
}
