using System;
using System.ComponentModel;
using System.Drawing;

namespace Lab_1
{
    internal class RotateFilter : Filters
    {
        protected float angleDegrees = 45.0f; // Change this value as needed

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            // Calculate rotation center
            int centerX = sourceImage.Width / 2;
            int centerY = sourceImage.Height / 2;

            // Convert angle to radians
            float angleRadians = (float)(angleDegrees * Math.PI / 180.0);

            // Применение фильтра
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    // Calculate rotated coordinates
                    float rotatedX = (float)(Math.Cos(angleRadians) * (i - centerX) - Math.Sin(angleRadians) * (j - centerY) + centerX);
                    float rotatedY = (float)(Math.Sin(angleRadians) * (i - centerX) + Math.Cos(angleRadians) * (j - centerY) + centerY);

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
