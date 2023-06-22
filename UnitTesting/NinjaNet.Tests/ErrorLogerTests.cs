using System;
using TestNinja.Fundamentals;

namespace NinjaNet.Tests
{
	public class ErrorLogerTests
	{
		[Test]
		public void Log_WhenCalled_SetTheLastErrorProperty()
		{
			var logger = new ErrorLogger();
			logger.Log("a");
			Assert.That(logger.LastError, Is.EqualTo("a"));

		}

		[Test]
		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		public void Log_InvalidError_ThrowArgumentNullExeption(string error)
		{
			var logger = new ErrorLogger();

			Assert.That(() => logger.Log(error), Throws.ArgumentNullException);

		}
		[Test]
		public void Log_validError_RaiseErrorLoggedEvent()
		{
			var logger = new ErrorLogger();
			var id = Guid.Empty;
			logger.ErrorLogged += (sender, args) => { id = args; };
			logger.Log("a");
			Assert.That(id, Is.Not.EqualTo(Guid.Empty));
		}

		
		
	}
}

