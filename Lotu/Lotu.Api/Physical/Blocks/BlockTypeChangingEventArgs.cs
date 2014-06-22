using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotu.Api.Physical.Blocks
{
	public class BlockTypeChangingEventArgs : EventArgs
	{
		public Block Block { get; private set; }
		public BlockType NewBlockType { get; private set; }

		/// <summary>
		/// Gets whether the event has been canceled.  Note that this is not guaranteed to be
		/// accurate when accessed by event handlers.  Avoid relying on this.
		/// </summary>
		public volatile bool IsCanceled { get; private set; }

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
