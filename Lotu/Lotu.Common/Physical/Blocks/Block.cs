using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lotu.Api.Physical;
using Lotu.Api.Physical.Blocks;

namespace Lotu.Common.Physical.Blocks
{
	public abstract class Block : IBlock
	{
		private readonly Location m_Location;
		private BlockType m_Type;

		protected Block(Location location)
		{
			m_Location = location;
		}

		public async Task<bool> TrySetTypeAsync(BlockType type)
		{
			var result = await Location.World.OnBlockTypeChangingAsync(this, type);

			if (result)
			{
				m_Type = type;
				await Location.World.OnBlockTypeChangedAsync(this, type);
			}

			return result;
		}

		public Location Location
		{
			get
			{
				return m_Location;
			}
		}

		public BlockType Type
		{
			get
			{
				return m_Type;
			}
		}
	}
}
