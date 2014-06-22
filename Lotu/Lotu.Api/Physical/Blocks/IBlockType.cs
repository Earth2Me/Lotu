using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotu.Api.Physical.Blocks
{
	public interface IBlockType
	{
		int Id { get; }
		string Name { get; }
		VolumeType VolumeType { get; }
	}
}
