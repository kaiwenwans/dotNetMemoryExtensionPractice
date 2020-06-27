using System;
using System.Threading;
using System.Text;
using System.Diagnostics;

namespace MemoryTraceAndOptimize
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("press any key to start");
			Console.ReadKey();
			var watch = Stopwatch.StartNew();
			var orderResult = "true,T123456789,10000,100";
			for (var i = 0; i < 1000000; i++)
			{
				GetOrderId(orderResult);
			}
			watch.Stop();
			Console.WriteLine($"ms:{watch.ElapsedMilliseconds}");
			Console.WriteLine("press any key to stop");
			Console.ReadKey();
		}

		static ReadOnlyMemory<char> GetOrderId(string orderResult)
		{
			var orderResultSpan = orderResult.AsMemory();
			//var isSuccess= orderResultSpan.Slice(0, 4);
			var orderId = orderResultSpan.Slice(5, 10);
			//var cost = orderResultSpan.Slice(16, 5);
			//var bonus = orderResultSpan.Slice(22, 3);
			return orderId;
		}
	}
}