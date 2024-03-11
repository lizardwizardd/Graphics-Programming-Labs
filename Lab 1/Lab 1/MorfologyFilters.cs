using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class MorfologyFilters : Filters
    {
        protected int[,] mask;
        protected int mode; // 0 - dilate, 1 - erode
        
        public MorfologyFilters()
        {
            mask = new int[,] {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 } };
        }

        public MorfologyFilters(int[,] mask)
        {
            this.mask = mask;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = mask.GetLength(0) / 2;
            int radiusY = mask.GetLength(1) / 2;
            int minR = 255;
            int minG = 255;
            int minB = 255;
            int maxR = 0;
            int maxG = 0;
            int maxB = 0;

            for (int i = -radiusX; i <= radiusX; i++)
                for (int j = -radiusY; j <= radiusY; j++)
                {
                    if (mode == 0) // dilate
                    {
                        if ((mask[i + radiusX, j + radiusY] != 0) && (sourceImage.GetPixel(x + i, y + j).R > maxR))
                            maxR = sourceImage.GetPixel(x + i, y + j).R;
                        if ((mask[i + radiusX, j + radiusY] != 0) && (sourceImage.GetPixel(x + i, y + j).G > maxG))
                            maxG = sourceImage.GetPixel(x + i, y + j).G;
                        if ((mask[i + radiusX, j + radiusY] != 0) && (sourceImage.GetPixel(x + i, y + j).B > maxB))
                            maxB = sourceImage.GetPixel(x + i, y + j).B;
                    }
                    else if (mode == 1) // erode
                    {
                        if ((mask[i + radiusX, j + radiusY] != 0) && (sourceImage.GetPixel(x + i, y + j).R < minR))
                            minR = sourceImage.GetPixel(x + i, y + j).R;
                        if ((mask[i + radiusX, j + radiusY] != 0) && (sourceImage.GetPixel(x + i, y + j).G < minG))
                            minG = sourceImage.GetPixel(x + i, y + j).G;
                        if ((mask[i + radiusX, j + radiusY] != 0) && (sourceImage.GetPixel(x + i, y + j).B < minB))
                            minB = sourceImage.GetPixel(x + i, y + j).B;
                    }
                }
            if (mode == 0)
                return Color.FromArgb(maxR, maxG, maxB);
            else 
                return Color.FromArgb(minR, minG, minB);
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            int radiusX = mask.GetLength(0) / 2;
            int radiusY = mask.GetLength(1) / 2;
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = radiusX; i < sourceImage.Width - radiusX; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = radiusY; j < sourceImage.Height - radiusY; j++)
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
            }
            return resultImage;
        }
    }
}
