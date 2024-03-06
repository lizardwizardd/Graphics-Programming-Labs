using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class SharpnessFilter : MatrixFilter
    {
        public SharpnessFilter()
        {
            int sizeX = 3;
            int sizeY = 3;

            float[,] _kernel = {
                { -1.0f, -1.0f, -1.0f },
                { -1.0f,  9.0f, -1.0f },
                { -1.0f, -1.0f, -1.0f }
            };

            this.kernel = _kernel;
        }
    }
}
