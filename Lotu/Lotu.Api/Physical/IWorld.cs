using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lotu.Api.Physical.Blocks;

namespace Lotu.Api.Physical
{
	public interface IWorld
	{
		event EventHandler<BlockTypeChangingEventArgs> BlockTypeChangingAsync;
		event EventHandler<BlockTypeChangedEventArgs> BlockTypeChangedAsync;

		public async Task<bool> OnBlockTypeChangingAsync(IBlock block, IBlockType newType);

		public async Task OnBlockTypeChangedAsync(IBlock block, IBlockType oldType);
	}
}
