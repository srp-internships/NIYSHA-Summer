using System;
using Moq;
using TestNinja.Mocking;
using TestNinjaNet.Mocking;

namespace NinjaNet.Tests.Mocking
{
	public class EmployeeControllerTests
	{
		[Test]
		public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
		{
			var storage = new Mock<IEmployeeStorage>();
			var controller = new EmployeeController(storage.Object);

			controller.DeleteEmployee(1);
			storage.Verify(s => s.DeleteEmployee(1));
		}

     
    }
}

