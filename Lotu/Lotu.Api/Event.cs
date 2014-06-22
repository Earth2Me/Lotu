using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotu.Api
{
	public static class Event
	{
		public static T Invoke<T>(EventHandler<T> evt, string name, object sender, T args)
			where T : EventArgs
		{
			if (evt == null)
			{
				return args;
			}

			try
			{
				evt(sender, args);
			}
			catch (Exception ex)
			{
				Trace.Fail(string.Format("{0} fired by {1} threw an exception", name, sender.GetType()), ex.ToString());
			}

			return args;
		}
	}
}
