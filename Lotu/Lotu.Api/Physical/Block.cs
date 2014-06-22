using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lotu.Api.Physical.Material;

namespace Lotu.Api.Physical
{
	public abstract class Block
	{
		private readonly Location m_Location;
		private readonly BlockType m_Type;

		protected Block(Location location)
		{
			m_Location = location;
		}

		public Location Location
		{
			get
			{
				return m_Location;
			}
		}
	}
}
