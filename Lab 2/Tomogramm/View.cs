﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Math;

namespace Tomogramm
{
    class View
    {
        Bitmap textureImage;
        int VBOtexture;

        public void SetupView(int width, int height)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity(); 
            GL.Ortho(0, Bin.X, 0, Bin.Y, -1, 1);
            GL.Viewport(0, 0, width, height);
        }

        int Clamp(int value, int min, int max)
        {
            return Max(0, Min(value, max));
        }

        Color TransferFunction(short value, int max, int min)
        {
            int newval = Clamp((value - min) * 255 / (max - min), 0, 255);
            return Color.FromArgb(newval, newval, newval);
        }

        // QUADS --------------------------------------------------------------
        public void DrawQuads(int layerNumber, int max, int min)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(BeginMode.Quads);
            for (int x = 0; x < Bin.X - 1; x++)
                for (int y = 0; y < Bin.Y - 1; y++)
                {
                    short value;

                    value = Bin.array[x + y * Bin.X + layerNumber * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value, max, min));
                    GL.Vertex2(x, y);

                    value = Bin.array[x + (y + 1) * Bin.X + layerNumber * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value, max, min));
                    GL.Vertex2(x, y + 1);

                    value = Bin.array[x + 1 + (y + 1) * Bin.X + layerNumber * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value, max, min));
                    GL.Vertex2(x + 1, y + 1);

                    value = Bin.array[x + 1 + y * Bin.X + layerNumber * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value, max, min));
                    GL.Vertex2(x + 1, y);
                }
            GL.End();
        }

        // QUAD STRIP ---------------------------------------------------------
        public void QuadStrip(int layerNumber, int max, int min)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(BeginMode.QuadStrip);

            for (int y = 0; y < Bin.Y - 1; y++)
            {
                if (y % 2 == 0)
                {
                    for (int x = 0; x < Bin.X - 1; x++)
                    {
                        short value1 = Bin.array[x + y * Bin.X + layerNumber * Bin.X * Bin.Y];
                        GL.Color3(TransferFunction(value1, max, min));
                        GL.Vertex2(x, y);

                        short value4 = Bin.array[x + 1 + (y + 1) * Bin.X + layerNumber * Bin.X * Bin.Y];
                        GL.Color3(TransferFunction(value4, max, min));
                        GL.Vertex2(x + 1, y + 1);
                    }
                }
                else
                {
                    for (int x = Bin.X - 1; x > 0; x--)
                    {
                        short value1 = Bin.array[x + y * Bin.X + layerNumber * Bin.X * Bin.Y];
                        GL.Color3(TransferFunction(value1, max, min));
                        GL.Vertex2(x, y);

                        short value4 = Bin.array[x - 1 + (y + 1) * Bin.X + layerNumber * Bin.X * Bin.Y];
                        GL.Color3(TransferFunction(value4, max, min));
                        GL.Vertex2(x - 1, y + 1);
                    }
                }
            }

            GL.End();
        }

        // TEXTURE ------------------------------------------------------------
        public void Load2DTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);
            BitmapData data = textureImage.LockBits(
                new Rectangle(0, 0, textureImage.Width, textureImage.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb
            );
            GL.TexImage2D(
                TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte, data.Scan0
            );
            textureImage.UnlockBits(data);
            GL.TexParameter(TextureTarget.Texture2D, 
                            TextureParameterName.TextureMinFilter,
                            (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, 
                            TextureParameterName.TextureMagFilter,
                            (int)TextureMinFilter.Linear);
            ErrorCode Er = GL.GetError();
            string str = Er.ToString();
        }

        public void generateTextureImage(int LayerNumber, int max, int min)
        {
            textureImage = new Bitmap(Bin.X, Bin.Y);
            for (int i = 0; i < Bin.X; i++)
                for (int j = 0; j < Bin.Y; j++)
                {
                    int PixelNumber = i + j * Bin.X + LayerNumber * Bin.X * Bin.Y;
                    textureImage.SetPixel(i, j, TransferFunction(Bin.array[PixelNumber], max, min));
                }
        }

        public void DrawTexture()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, VBOtexture);

            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(0, 0);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(0, Bin.Y);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(Bin.X, Bin.Y);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(Bin.X, 0);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
        }
    }
}