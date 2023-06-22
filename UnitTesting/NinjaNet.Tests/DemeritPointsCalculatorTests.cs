using System;
using TestNinja.Fundamentals;
namespace NinjaNet.Tests

{
	public class DemeritPointsCalculatorTests
	{
		[Test]
           public void GetPointsCalculaton_IfSpeedLessThanZero_ReturnExeption()
		{
			var point = new DemeritPointsCalculator();

            Assert.That(() => point.CalculateDemeritPoints(-1),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

		}

        [Test]
        public void GetPointsCalculaton_IfSpeedIsMoreThanMaxSpeed_ReturnExeption()
        {
            var point = new DemeritPointsCalculator();

            Assert.That(() => point.CalculateDemeritPoints(305),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }


        [Test]
        [TestCase(0,0)]
        [TestCase(26,0)]
        [TestCase(75,2)]

        public void GetPointsCalculaton_SpeedWhenCalled_ReturnPoints(int a,int b)
        {
            var point = new DemeritPointsCalculator();
            var result = point.CalculateDemeritPoints(a);

            Assert.That(result, Is.EqualTo(b));
        }
      
    }
}

