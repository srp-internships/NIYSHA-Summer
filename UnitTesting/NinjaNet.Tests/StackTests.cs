using System;
using System.Drawing;
using TestNinja.Fundamentals;

namespace NinjaNet.Tests
{
	public class StackTests
	{
        [Test]
		public void Push_IfStackIsEqualToNull_ReturnExeption()
		{
		
         var stack= new TestNinja.Fundamentals.Stack<string>();
			
            Assert.That(() => stack.Push(null),Throws.ArgumentNullException);
        }

        [Test]
        public void Push_TheObject_AddToStack()
        {

           var stack = new TestNinja.Fundamentals.Stack<string>();
            stack.Push("A");
              Assert.That(stack.Count, Is.EqualTo(1));
          
        }

        [Test]
        public void Pull_IfStackCountIsEqualToNull_ReturnExeption()
        {

            var stack = new TestNinja.Fundamentals.Stack<string>();
           
            Assert.That(() => stack.Pop(),Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_TheObject_RemoveFromStock()
        {

            var stack = new TestNinja.Fundamentals.Stack<string>();
            stack.Push("A");
            stack.Push("B");
           var result= stack.Pop();

            Assert.That(result, Is.EqualTo("B"));
            Assert.That(stack.Count, Is.EqualTo(1));
        }


        [Test]
        public void Peek_IfStackCountIsEqualToNull_ReturnExeption()
        {

            var stack = new TestNinja.Fundamentals.Stack<string>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_TheObject_RemoveFromStock()
        {

            var stack = new TestNinja.Fundamentals.Stack<string>();
            stack.Push("A");
            stack.Push("B");
            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("B"));
            Assert.That(stack.Count, Is.EqualTo(2));

        }

    }
}

