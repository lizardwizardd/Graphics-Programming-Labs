using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class GlassFilter : Filters
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            // Применение фильтра
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Random rand = new Random();
                    // Calculate rotated coordinates
                    double rotatedX = i + (rand.NextDouble()-0.5)*10;
                    double rotatedY = j + (rand.NextDouble() - 0.5) * 10;

                    // Round to the nearest integer to get the nearest neighbor
                    int nearestX = (int)Math.Round(rotatedX);
                    int nearestY = (int)Math.Round(rotatedY);

                    // Check if the new position is within the image bounds
                    if (nearestX >= 0 && nearestX < sourceImage.Width && nearestY >= 0 && nearestY < sourceImage.Height)
                    {
                        resultImage.SetPixel(i, j, sourceImage.GetPixel(nearestX, nearestY));
                    }
                    else
                    {
                        // Set pixels outside the bounds to black
                        resultImage.SetPixel(i, j, Color.Black);
                    }
                }

                worker.ReportProgress((int)((float)i / sourceImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
            }

            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
