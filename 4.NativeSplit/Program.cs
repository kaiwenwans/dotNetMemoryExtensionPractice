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

		static (string IsSuccess, string OrderId, string Cost, string Bonus) GetOrderInfo(string orderResult)
		{
			var splitArray = orderResult.Split(",");			
			return (splitArray[0], splitArray[1], splitArray[2], splitArray[3]);
		}
	}
}