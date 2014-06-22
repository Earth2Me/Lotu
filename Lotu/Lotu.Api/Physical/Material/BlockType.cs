using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotu.Api.Physical.Material
{
	public abstract class BlockType
	{
		public abstract int Id { get; }
		public abstract string Name { get; }
		public abstract VolumeType VolumeType { get; }
	}
}
