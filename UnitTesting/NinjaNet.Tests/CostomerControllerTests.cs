using System;
using TestNinja.Fundamentals;

namespace NinjaNet.Tests
{
	public class CostomerControllerTests
	{
		[Test]
		public void GetCustomer_IdIsZero_ReturnNotFound()
		{
			var controller = new CustomerController();
			var result = controller.GetCustomer(0);
			//NotFound
			Assert.That(result, Is.TypeOf<NotFound>());
			//NotFound or one of its derivaties
            Assert.That(result, Is.InstanceOf<NotFound>());


        }
	
	}
}

