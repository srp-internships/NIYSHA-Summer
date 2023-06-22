using TestNinja.Fundamentals;

namespace NinjaNet.Tests
{
	public class MathTests
	{
		private TestNinja.Fundamentals.Math _math;
		[SetUp]

		public void SetUp()
		{
			_math = new TestNinja.Fundamentals.Math();

		}

		[Test]
		public void Add_WhenCalled_ReturnTheSumOfArguments()
		{
			var result = _math.Add(1, 2);
			Assert.That(result, Is.EqualTo(3));
		}

		[Test]
		[TestCase(2, 1, 2)]
		[TestCase(1, 2, 2)]
		[TestCase(1, 1, 1)]

		public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
		{
			var result = _math.Max(a, b);
			Assert.That(result, Is.EqualTo(expectedResult));

		}

		[Test]
		public void GetOddNumber_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
		{
			var resault=_math.GetOddNumbers(5);
			//	Assert.That(resault, Is.Not.Empty);
			//	Assert.That(resault.Count(), Is.EqualTo(3));

			//Assert.That(resault, Does.Contain(1));
			//    Assert.That(resault, Does.Contain(3));
			//   Assert.That(resault, Does.Contain(5));
			Assert.That(resault, Is.EquivalentTo(new[] { 1, 3, 5 }));
			//Assert.That(resault, Is.Unique);
			//Assert.That(resault, Is.Ordered);
        }

		
    }
}

