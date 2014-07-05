using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotu.Api.Physical.Blocks
{
	public class BlockTypeChangedEventArgs : EventArgs
	{
		public IBlock Block { get; private set; }
		public IBlockType OldBlockType { get; private set; }

		public BlockTypeChangedEventArgs(IBlock block, IBlockType oldBlockType)
		{
			Block = block;
			OldBlockType = oldBlockType;
		}
	}
}
