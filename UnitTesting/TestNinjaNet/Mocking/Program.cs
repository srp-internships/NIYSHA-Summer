using System;
using TestNinja.Mocking;

namespace TestNinjaNet.Mocking
{
	public class Program
	{
		public static void Main()
		{
			var service = new VideoService();
			var titel = service.ReadVideoTitle();

		}
	}
}

