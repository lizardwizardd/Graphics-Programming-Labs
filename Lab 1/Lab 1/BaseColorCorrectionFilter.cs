using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    internal class BaseColorCorrectionFilter : Filters
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
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            /*
            // Прочитать из консоли изначальный цвет
            Console.WriteLine("Enter base color R:");
            int baseR = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter base color G:");
            int baseG = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter base color B:");
            int baseB = Convert.ToInt32(Console.ReadLine());

            // Прочитать из консоли цвет, к которому приводим
            Console.WriteLine("Enter corrected color R:");
            int newR = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter corrected color G:");
            int newG = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter corrected color B:");
            int newB = Convert.ToInt32(Console.ReadLine());
            */

            // Использование консоли не подразумевается с Windows Forms,
            // поэтому цвета задаются в коде
            int baseR = 41;
            int baseG = 125;
            int baseB = 190;

            int newR = 76;
            int newG = 165;
            int newB = 135;

            modifierR = (float)newR / baseR;
            modifierG = (float)newG / baseG;
            modifierB = (float)newB / baseB;

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
