using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotu.Api.Physical.Blocks
{
	public interface IBlock
	{
		Location Location { get; }

		IBlockType Type { get; }
	}
}
