using System;
using TestNinja.Fundamentals;

namespace NinjaNet.Tests
{
	public class FizzBuzzTests
	{
        [Test]
        public void GetFizzBuzz_IfNumberIsDivisibleBy3And5_ReturnFizzAndBuzz()
        {
            var fizzbuzz =FizzBuzz.GetOutput(15);
            Assert.That(fizzbuzz, Is.EqualTo("FizzBuzz"));
            
        }
        [Test]
        public void GetFizz_IfNumberIsDivisibleBy3_ReturnFizz()
        {
            var fizz = FizzBuzz.GetOutput(9);
            Assert.That(fizz, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetBuzz_IfNumberIsDivisibleBy5_ReturnBuzz()
        {
            var buzz = FizzBuzz.GetOutput(10);
            Assert.That(buzz, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetString_IfNumberIsNotDivisibleBy3And5_ReturnString()
        {
            var number = FizzBuzz.GetOutput(1);
            Assert.That(number, Is.EqualTo("1"));
        }
    }

}

