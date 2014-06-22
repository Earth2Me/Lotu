using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotu.Api.Physical.Material
{
	public class BlockTypeChangedEventArgs : EventArgs
	{
		public Block Block { get; private set; }
		public BlockType OldBlockType { get; private set; }

		public BlockTypeChangedEventArgs(Block block, BlockType oldBlockType)
		{
			Block = block;
			OldBlockType = oldBlockType;
		}
	}
}
