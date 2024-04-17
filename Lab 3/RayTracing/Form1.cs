using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace RayTracing
{
    public partial class Form1 : Form
    {
        int BasicProgramID;
        int BasicVertexShader;
        int BasicFragmentShader;

        int vbo_position;
        int attribute_vpos;
        int attribute_rotate;

        int uniform_pos;
        int uniform_aspect;

        Vector3 campos;
        float aspect = 4/3;
        private Vector3[] vertdata;
        int uniform_reflectionCoef;

        void loadShader(String filename, ShaderType type, int program, out int address)
        {
            address = GL.CreateShader(type);
            using (System.IO.StreamReader sr = new System.IO.StreamReader(filename))
            {
                GL.ShaderSource(address, sr.ReadToEnd());
            }
            GL.CompileShader(address);
            GL.AttachShader(program, address);
            Console.WriteLine(GL.GetShaderInfoLog(address));
        }

        void InitShaders()
        {
            BasicProgramID = GL.CreateProgram();
            loadShader("..\\..\\raytracing.vert", ShaderType.VertexShader, BasicProgramID, out BasicVertexShader);
            loadShader("..\\..\\raytracing.frag", ShaderType.FragmentShader, BasicProgramID, out BasicFragmentShader);
            GL.LinkProgram(BasicProgramID);
            int status = 0;
            Console.WriteLine(GL.GetProgramInfoLog(BasicProgramID));

            vertdata = new Vector3[] {
                new Vector3(-1f, -1f, 0f),
                new Vector3( 1f, -1f, 0f),
                new Vector3( 1f, 1f, 0f),
                new Vector3(-1f, 1f, 0f)
            };
            GL.GenBuffers(1, out vbo_position);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_position);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(vertdata.Length *
            Vector3.SizeInBytes), vertdata, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(attribute_vpos, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.Uniform3(uniform_pos, campos);
            GL.Uniform1(uniform_aspect, aspect);
        }

        private static bool Init()
        {
            GL.Enable(EnableCap.ColorMaterial);
            GL.ShadeModel(ShadingModel.Smooth);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);

            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            return true;
        }

        void SetUniformVec3(string name, OpenTK.Vector3 value)
        {
            GL.Uniform3(GL.GetUniformLocation(BasicProgramID, name), value);
        }

        void SetUniformFloat(string name, float value)
        {
            GL.Uniform1(GL.GetUniformLocation(BasicProgramID, name), value);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.ClearColor(Color.AliceBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.UseProgram(BasicProgramID);


            float reflectionCoefValue = (float)trackBar1.Value / 100.0f;
            uniform_reflectionCoef = GL.GetUniformLocation(BasicProgramID, "u_reflectionCoef");
            GL.Uniform1(uniform_reflectionCoef, 0.6);

            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0, 1);
            GL.Vertex2(-1, -1);

            GL.TexCoord2(1, 1);
            GL.Vertex2(1, -1);

            GL.TexCoord2(1, 0);
            GL.Vertex2(1, 1);

            GL.TexCoord2(0, 0);
            GL.Vertex2(-1, 1);

            GL.End();
            glControl1.SwapBuffers();
            GL.UseProgram(0);
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            Init();
            InitShaders();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            glControl1.Invalidate();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            glControl1.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            glControl1.Invalidate();
        }
    }
};
