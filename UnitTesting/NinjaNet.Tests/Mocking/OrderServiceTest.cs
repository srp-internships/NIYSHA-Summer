using System;
using Moq;
using TestNinja.Mocking;

namespace NinjaNet.Tests.Mocking
{
	public class OrderServiceTest
	{

		[Test]
		public void PlaceOrder_WhenCalled_StoreTheOrder()
		{
			var storage = new Mock<IStorage>();
			var service = new OrderService(storage.Object);
			var order = new Order();
			service.PlaceOrder(order);
			storage.Verify(s => s.Store(order));
		}
	}
}

