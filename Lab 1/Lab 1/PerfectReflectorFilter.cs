using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class PerfectReflectorFilter : Filters
    {
        private float modifierR;
        private float modifierG;
        private float modifierB;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                (int)(sourceColor.R * modifierR),
                (int)(sourceColor.G * modifierG),
                (int)(sourceColor.B * modifierB));
            return resultColor;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            // Инициализация с 1, чтобы избежать деления на 0
            uint maxR = 1;
            uint maxG = 1;
            uint maxB = 1;

            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            // Найти максимальную яркость каждого цветогого канала
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    maxR = Math.Max(sourceImage.GetPixel(i, j).R, maxR);
                    maxG = Math.Max(sourceImage.GetPixel(i, j).G, maxG);
                    maxB = Math.Max(sourceImage.GetPixel(i, j).B, maxB);
                }

                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
            }

            // Найти коэффициенты для яркости цветов
            modifierR = 255.0f / maxR;
            modifierG = 255.0f / maxG;
            modifierB = 255.0f / maxB;

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
