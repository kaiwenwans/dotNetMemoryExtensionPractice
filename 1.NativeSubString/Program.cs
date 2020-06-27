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
				GetOrderInfo(orderResult);
			}
			watch.Stop();
			Console.WriteLine($"ms:{watch.ElapsedMilliseconds}");
			Console.WriteLine("press any key to stop");
			Console.ReadKey();
		}

		static string GetOrderInfo(string orderResultString)
		{
			//string isSuccess = orderResultString.Substring(0,4);
			string orderId = orderResultString.Substring(5, 10);
			//string cost = orderResultString.Substring(16, 5);
			//string bonus = orderResultString.Substring(22, 3);
			return orderId;
		}
	}
}