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

		static ReadOnlySpan<char> GetOrderInfo(string orderResult)
		{
			var orderResultSpan = orderResult.AsMemory().Span;
			var splitEnumerator = orderResultSpan.SplitString(",");
			splitEnumerator.MoveNext();
			//var isSuccess = splitEnumerator.Current;
			splitEnumerator.MoveNext();
			var orderId = splitEnumerator.Current;
			//splitEnumerator.MoveNext();
			//var cost = splitEnumerator.Current;
			//splitEnumerator.MoveNext();
			//var bonus = splitEnumerator.Current;
			return orderId;
		}
	}

	public static class SpanExtention
	{
		public static SplitStringEnumerator SplitString(this ReadOnlySpan<char> span, string splitString, StringComparison comparison = StringComparison.Ordinal)
		{
			return new SplitStringEnumerator(span, splitString, comparison);
		}

		public ref struct SplitStringEnumerator
		{
			private ReadOnlySpan<char> _str;
			private string _split;
			private StringComparison _comparison;
			public SplitStringEnumerator(ReadOnlySpan<char> str, string splitString, StringComparison comparison = StringComparison.Ordinal)
			{
				_str = str;
				_split = splitString;
				_comparison = comparison;
				Current = default;
			}
			public bool MoveNext()
			{
				var span = _str;
				if (span.Length == 0) return false;
				var index = span.IndexOf(_split, _comparison);
				if (index == -1)
				{
					_str = ReadOnlySpan<char>.Empty; ;
					Current = span;
					return true;
				}
				Current = span.Slice(0, index);
				_str = span.Slice(index + 1);
				return true;
			}

			public ReadOnlySpan<char> Current { get; private set; }
		}
	}
}