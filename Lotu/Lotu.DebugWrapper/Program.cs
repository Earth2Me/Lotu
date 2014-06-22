using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lotu.Engine;
using OpenTK;
using OpenTK.Graphics;

namespace Lotu.DebugWrapper
{
	public class Program
	{
		[MTAThread]
		public static void Main(string[] args)
		{
			var traceListener = new ConsoleTraceListener(true);
			Debug.Listeners.Add(traceListener);
			Debug.AutoFlush = true;

			var game = new Game(
				width: 1024,
				height: 768,
				mode: new GraphicsMode(
					color: new ColorFormat(32),
					depth: 24,
					stencil: 8,
					samples: 4
				),
				title: "DEBUG: Legends of the Universe",
				options: GameWindowFlags.Default,
				device: DisplayDevice.Default,
				major: 4,
				minor: 0,
				flags: GraphicsContextFlags.ForwardCompatible | GraphicsContextFlags.Debug
			);

			game.Run();
		}
	}
}
