using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class GlowingEdgesFilter : Filters
    {


        float[,] kernelx = { { -1.0f, -1.0f, -1.0f },
                                { 0f, 0f, 0f } ,
                                { 1.0f, 1.0f, 1.0f } };
        float[,] kernely = { { -1.0f, 0f, 1.0f },
                                { -1.0f, 0f, 1.0f },
                                { -1.0f,0f, 1.0f } };
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            //int radiusX = kernelx.GetLength(0) / 2;
            //int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            float RX = 0, GX = 0, BX = 0, RY = 0, GY = 0, BY = 0;

            for (int l = -1; l <= 1; l++)
            {
                for (int k = -1; k <= 1; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    RX += neighborColor.R * kernelx[k + 1, l + 1];
                    GX += neighborColor.G * kernelx[k + 1, l + 1];
                    BX += neighborColor.B * kernelx[k + 1, l + 1];
                }
            }
            for (int l = -1; l <= 1; l++)
            {
                for (int k = -1; k <= 1; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    RY += neighborColor.R * kernely[k + 1, l + 1];
                    GY += neighborColor.G * kernely[k + 1, l + 1];
                    BY += neighborColor.B * kernely[k + 1, l + 1];
                }
            }
            resultR = (float)Math.Sqrt(RX * RX + RY * RY);
            resultG = (float)Math.Sqrt(GX * GX + GY * GY);
            resultB = (float)Math.Sqrt(BX * BX + BY * BY);
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }
    }
}
