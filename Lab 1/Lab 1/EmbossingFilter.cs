using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Lab_1
{
     class EmbossingFilter : Filters
    {

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float[,] kernel = { { 0.0f, 1.0f,0.0f },
                                { 1.0f, 0f, -1.0f } ,
                                { 0.0f, -1.0f, 0.0f } };
            //int radiusX = kernelx.GetLength(0) / 2;
            //int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -1; l <= 1; l++)
            {
                for (int k = -1; k <= 1; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + 1, l + 1];
                    resultG += neighborColor.G * kernel[k + 1, l + 1];
                    resultB += neighborColor.B * kernel[k + 1, l + 1];
                }
            }
            resultR =(resultR+ 255)/2;
            resultG =(resultG+ 255)/2;
            resultB =(resultB+ 255)/2;
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }
    }
}
