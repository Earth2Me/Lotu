using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lotu.Api.Base.Physical.Material;
using Lotu.Api.Base.Physical.Material.Blocks;

namespace Lotu.Api.Base.Physical
{
	public abstract class World
	{
		public event EventHandler<BlockTypeChangingEventArgs> BlockTypeChangingAsync;
		public event EventHandler<BlockTypeChangedEventArgs> BlockTypeChangedAsync;

		/// <summary>
		/// Responsible for firing BlockTypeChanging event.  Can cancel.
		/// </summary>
		/// <param name="block">Block that is to be changed, in its pre-change state</param>
		/// <param name="newType">New type that the block is to receive</param>
		/// <returns><c>true</c> to continue the event; <c>false</c> to cancel</returns>
		protected internal async Task<bool> OnBlockTypeChangingAsync(Block block, BlockType newType)
		{
			var e = new BlockTypeChangingEventArgs(block, newType);

			await Event.InvokeParallelAsync(BlockTypeChangingAsync, this, e);

			return !e.IsCanceled;
		}

		/// <summary>
		/// Responsible for firing BlockTypeChanged event.  Cannot cancel.
		/// </summary>
		/// <param name="block">Block that is to be changed, in its post-change state</param>
		/// <param name="oldType">Pre-change type of the block</param>
		protected internal async Task OnBlockTypeChangedAsync(Block block, BlockType oldType)
		{
			await Event.InvokeParallelAsync(BlockTypeChangedAsync, this, new BlockTypeChangedEventArgs(block, oldType));
		}
	}
}
