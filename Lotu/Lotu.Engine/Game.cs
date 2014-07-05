using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Lotu.Engine
{
	public class Game : GameWindow
	{
		private int m_VertexArray;
		private int m_VertexBuffer;
		private const float V = 15f / 16f;
		private const float Z = 0f;
		private float[,] m_VertexData = new float[,] {
			{ -V, -V,  Z },
			{  V, -V,  Z },
			{  Z,  V,  Z },
		};

		public Game()
			: base()
		{
		}

		public Game(int width, int height, GraphicsMode mode, string title, GameWindowFlags options, DisplayDevice device, int major, int minor, GraphicsContextFlags flags)
			: base(width, height, mode, title, options, device, major, minor, flags)
		{
			Load += Game_Load;
			UpdateFrame += Game_UpdateFrame;
			RenderFrame += Game_RenderFrame;
			Resize += Game_Resize;
		}

		private void Game_Resize(object sender, EventArgs e)
		{
			Context.Update(WindowInfo);

			GL.DeleteVertexArray(m_VertexArray);
			GL.DeleteBuffer(m_VertexBuffer);

			UpdateVertexData();
		}

		private void Game_Load(object sender, EventArgs e)
		{
			UpdateVertexData();
		}
		
		private void UpdateVertexData()
		{
			m_VertexArray = GL.GenVertexArray();
			GL.BindVertexArray(m_VertexArray);

			m_VertexBuffer = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, m_VertexBuffer);

			GL.BufferData(BufferTarget.ArrayBuffer, new IntPtr(m_VertexData.Length * sizeof(float)), m_VertexData, BufferUsageHint.StaticDraw);
		}

		void Game_UpdateFrame(object sender, FrameEventArgs e)
		{
		}

		void Game_RenderFrame(object sender, FrameEventArgs e)
		{
			GL.ClearColor(Color4.DarkBlue);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			GL.EnableVertexAttribArray(0);
			try
			{
				GL.BindBuffer(BufferTarget.ArrayBuffer, m_VertexBuffer);
				GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
				GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
			}
			finally
			{
				GL.DisableVertexAttribArray(0);
			}

			SwapBuffers();
		}
	}
}
