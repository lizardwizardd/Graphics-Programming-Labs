using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        Bitmap originImage;
        Bitmap image;
        List<Bitmap> listImages = new List<Bitmap>();
        public Form1()
        {
            InitializeComponent();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png; *.jpg; *.bmp|All files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                originImage = new Bitmap(dialog.FileName);
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;

                pictureBox1.Refresh();
                listImages.Add(image);
                setAllToolStrimMenuBtn_Enable();
            }
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                listImages.Add(image);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BrightnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ���������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Filters filter = new HistogramEqualizationFilter();
            //((HistogramEqualizationFilter)filter).findMinMaxBrightness(image);
            //backgroundWorker1.RunWorkerAsync(filter);

            // �� ���� ��� ������� ����� minBrightness � maxBrightness
            // �� ���������� ������ RunWorkerAsync, ������� ��� ������

            Bitmap resultImage = new Bitmap(image.Width, image.Height);
            int minBrightness = 255;
            int maxBrightness = 0;

            // ����� ����������� � ������������ �������
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixelColor = image.GetPixel(i, j);
                    int brightness = (int)
                       ((pixelColor.R +
                         pixelColor.G +
                         pixelColor.B) / 3);

                    minBrightness = Math.Min(minBrightness, brightness);
                    maxBrightness = Math.Max(maxBrightness, brightness);
                }
            }

            // ��������� ������
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color sourceColor = image.GetPixel(i, j);

                    int R = (int)((sourceColor.R - minBrightness) *
                            (255.0 / (maxBrightness - minBrightness)));
                    int G = (int)((sourceColor.G - minBrightness) *
                            (255.0 / (maxBrightness - minBrightness)));
                    int B = (int)((sourceColor.B - minBrightness) *
                            (255.0 / (maxBrightness - minBrightness)));

                    R = Math.Clamp(R, 0, 255);
                    G = Math.Clamp(G, 0, 255);
                    B = Math.Clamp(B, 0, 255);

                    resultImage.SetPixel(i, j, Color.FromArgb(R, G, B));
                }

                progressBar1.Value = (int)((float)(i + 1) / image.Width * 100);
            }


            image = resultImage;
            pictureBox1.Image = image;
            pictureBox1.Refresh();

            progressBar1.Value = 0;
            progressBar1.Refresh();
        }

        private void ���������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MedianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ���������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Image|*.bmp|JPEG Image|*.jpg|PNG Image|*.png|All Files|*.*";
            saveFileDialog.Title = "Save Image";
            saveFileDialog.FileName = "image_edited";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ImageFormat saveImageFormat;
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1: // Bitmap
                            saveImageFormat = ImageFormat.Bmp;
                            break;
                        case 2: // JPEG
                            saveImageFormat = ImageFormat.Jpeg;
                            break;
                        case 3: // PNG
                            saveImageFormat = ImageFormat.Png;
                            break;
                        default: // Bitmap
                            saveImageFormat = ImageFormat.Bmp;
                            break;
                    }

                    image.Save(saveFileDialog.FileName, saveImageFormat);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = originImage;
            pictureBox1.Image = originImage;
            pictureBox1.Refresh();
            listImages = new List<Bitmap> { image };
        }
        private void setAllToolStrimMenuBtn_Enable()
        {
            �������ToolStripMenuItem.Enabled = true;
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filters = new EmbossingFilter();
            backgroundWorker1.RunWorkerAsync(filters);

        }

        private void �����ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (listImages.Count > 1)
            {
                image = listImages[listImages.Count - 2];
                pictureBox1.Image = image;
                pictureBox1.Refresh();
                listImages.RemoveAt(listImages.Count - 1);
            }
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayWorldFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png; *.jpg; *.bmp|All files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                originImage = new Bitmap(dialog.FileName);
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;

                pictureBox1.Refresh();
                listImages.Add(image);
                setAllToolStrimMenuBtn_Enable();
            }
        }

        private void �������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new PerfectReflectorFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �����������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BaseColorCorrectionFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MotionBlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ����������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MoveFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new RotateFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}