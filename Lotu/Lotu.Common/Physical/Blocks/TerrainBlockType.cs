using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lotu.Api.Physical.Blocks;

namespace Lotu.Common.Physical.Blocks
{
	public abstract class TerrainBlockType : BlockType
	{
		public override VolumeType VolumeType
		{
			get
			{
				return VolumeType.Terrain;
			}
		}
	}
}
