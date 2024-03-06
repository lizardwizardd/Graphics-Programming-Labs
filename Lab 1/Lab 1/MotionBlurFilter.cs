using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class MotionBlurFilter : MatrixFilter
    {
        public MotionBlurFilter()
        {
            int sizeX = 7;
            int sizeY = 7;

            //this.kernel = _kernel;

            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (i != j)
                    {
                        kernel[i, j] = 0.0f;
                    }
                    else
                    {
                        kernel[i, j] = 1.0f / sizeX;
                    }
                }
            }
        }
    }
}
