using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lotu.Api.Physical.Material;

namespace Lotu.Api.Physical
{
	public abstract class World
	{
		public event EventHandler<BlockTypeChangingEventArgs> BlockTypeChanging;
		public event EventHandler<BlockTypeChangedEventArgs> BlockTypeChanged;

		/// <summary>
		/// Responsible for firing BlockTypeChanging event.  Can cancel.
		/// </summary>
		/// <param name="block">Block that is to be changed, in its pre-change state</param>
		/// <param name="newType">New type that the block is to receive</param>
		/// <returns><c>true</c> to continue the event; <c>false</c> to cancel</returns>
		protected internal bool OnBlockTypeChanging(Block block, BlockType newType)
		{
			var e = Event.Invoke(BlockTypeChanging, "BlockTypeChanging", this, new BlockTypeChangingEventArgs(block, newType));
			return !e.IsCanceled;
		}

		/// <summary>
		/// Responsible for firing BlockTypeChanged event.  Cannot cancel.
		/// </summary>
		/// <param name="block">Block that is to be changed, in its post-change state</param>
		/// <param name="oldType">Pre-change type of the block</param>
		protected internal void OnBlockTypeChanged(Block block, BlockType oldType)
		{
			Event.Invoke(BlockTypeChanged, "BlockTypeChanged", this, new BlockTypeChangedEventArgs(block, oldType));
		}
	}
}
