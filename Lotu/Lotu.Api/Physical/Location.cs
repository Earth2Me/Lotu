using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotu.Api.Physical
{
	public sealed class Location : ICloneable
	{
		private readonly World m_World;
		private readonly long m_X;
		private readonly long m_Y;
		private readonly long m_Z;

		public Location(long x, long y, long z)
		{
			m_World = null;
			m_X = x;
			m_Y = y;
			m_Z = z;
		}

		public Location(World world, long x, long y, long z)
		{
			m_World = world;
			m_X = x;
			m_Y = y;
			m_Z = z;
		}

		public Location WithWorld(World world)
		{
			return new Location(world, X, Y, Z);
		}

		public Location Offset(int x, int y, int z)
		{
			return new Location(World, X + x, Y + y, Z + z);
		}

		public Location Clone()
		{
			return new Location(World, X, Y, Z);
		}

		#region ICloneable Members

		object ICloneable.Clone()
		{
			return Clone();
		}

		#endregion

		public World World
		{
			get
			{
				return m_World;
			}
		}

		public long X
		{
			get
			{
				return m_X;
			}
		}

		public long Y
		{
			get
			{
				return m_Y;
			}
		}

		public long Z
		{
			get
			{
				return Z;
			}
		}
	}
}
