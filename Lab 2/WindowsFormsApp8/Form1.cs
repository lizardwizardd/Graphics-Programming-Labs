using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics.OpenGL4;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        Bin bin;
        View view;
        bool loaded;
        int frameCount;
        DateTime nextFpsUpdate = DateTime.Now.AddSeconds(1);
        int currentLayer = 0;
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("Start");
            bin = new Bin();
            view = new View();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += Application_Idle;
            //Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            while (glControl2.IsIdle)
            {
                displayFPS();
                glControl2.Invalidate();
            }
        }

        private void glControl2_Paint(object sender, PaintEventArgs e)
        {
            if (loaded)
            {   
                view.DrawQuads(currentLayer);
                glControl2.SwapBuffers();
            }
        }

        void displayFPS()
        {
            if (DateTime.Now >= nextFpsUpdate)
            {
                this.Text = String.Format("CT Visualizer (fps={0})", frameCount);
                nextFpsUpdate = DateTime.Now.AddSeconds(1);
                frameCount += 1;
            }
            frameCount++;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog(); 
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string str = dialog.FileName;
                bin.readBin(str);
                view.SetupView(glControl2.Width, glControl2.Height);
                loaded = true;
                glControl2.Invalidate();
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentLayer = trackBar1.Value;
            Console.WriteLine(currentLayer.ToString());
            view.DrawQuads(currentLayer);
            glControl2.SwapBuffers();
        }
    }
}
