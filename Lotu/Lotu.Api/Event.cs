using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lotu.Api
{
	public static class Event
	{
		public static void Invoke<T>(EventHandler<T> evt, object sender, T args, [CallerMemberName] string invoker = null)
			where T : EventArgs
		{
			if (evt == null)
			{
				return;
			}

			try
			{
				evt(sender, args);
			}
			catch (Exception ex)
			{
				Trace.Fail(string.Format("{0} fired by {1} threw an exception", invoker, sender.GetType()), ex.ToString());
				throw;
			}
		}

		public static async Task InvokeAsync<T>(EventHandler<T> evt, object sender, T args, [CallerMemberName] string invoker = null)
			where T : EventArgs
		{
			if (evt == null)
			{
				return;
			}

			try
			{
				await Task.Run(() => evt(sender, args));
			}
			catch (Exception ex)
			{
				Trace.Fail(string.Format("{0} fired by {1} threw an exception", invoker, sender.GetType()), ex.ToString());
				throw;
			}
		}

		public static async Task InvokeParallelAsync<T>(EventHandler<T> evt, object sender, T args, [CallerMemberName] string invoker = null)
			where T : EventArgs
		{
			if (evt == null)
			{
				return;
			}



			var result = await Task.Run(() =>
			{
				try
				{
					return Parallel.ForEach(evt.GetInvocationList().Cast<EventHandler<T>>(), handler =>
					{
						handler(sender, args);
					});
				}
				catch (Exception ex)
				{
					Trace.Fail(string.Format("{0} fired by {1} threw an exception.", invoker, sender.GetType()), ex.ToString());
					throw;
				}
			});

			if (!result.IsCompleted)
			{
				throw new OperationCanceledException(string.Format("{0} fired by {1} was cancelled incorrectly during parallel execution.", invoker, sender.GetType()));
			}
		}
	}
}
