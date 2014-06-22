using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotu.Api.Physical.Material
{
	public delegate void BlockTypeChangingEventHandler(object sender, BlockTypeChangingEventArgs e);

	public class BlockTypeChangingEventArgs
	{
		public Block Block { get; private set; }
		public BlockType NewBlockType { get; private set; }
		public bool IsCanceled { get; private set; }

		public BlockTypeChangingEventArgs(Block block, BlockType newBlockType)
		{
			Block = block;
			NewBlockType = newBlockType;
		}

		public void Cancel()
		{
			IsCanceled = true;
		}
	}
}
