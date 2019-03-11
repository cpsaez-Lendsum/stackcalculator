using NUnit.Framework;
using StackOperations;
using StackOperations.BasicOperations;
using System.Collections.Generic;

namespace stackCalculator.tests
{
    class OperationMaxTests
    {

        private Stack<IStackItem> stack;
        private OperationMax operationMax;


        [SetUp]
        public void Setup()
        {
            this.stack = new Stack<IStackItem>();
            this.operationMax = new OperationMax();
        }

        [TestCase(6, new object[] { 1, 2, 3, 4, 5, 6, 2 })]
        [TestCase(3, new object[] { 1, 2, 3, 3 })]
        public void EvalTest(int expectedResult, object[] input)
        {
            this.fillStack(input);

            var result = operationMax.Eval(stack).Pop() as IntegerNumber;

            Assert.AreEqual(expectedResult, result.Value);
        }


        [TestCase(new object[] { 1, 2, 6, 8 , -1 })]
        [TestCase(new object[] { 2, 1, 3, "Hola" })]
        [TestCase(new object[] { "hola", 2, 1, 3 })]
        [TestCase(new object[] { 3 })]
        public void EvalTestMessage(object[] input)
        {
            this.fillStack(input);

            var result = operationMax.Eval(stack).Pop();

            Assert.IsInstanceOf(typeof(Message), result);
        }



        private void fillStack(object[] inputs)
        {
            foreach (object row in inputs)
            {
                if (row is string message)
                {
                    stack.Push(new Message { Value = message });
                }
                else if (row is int number)
                {
                    stack.Push(new IntegerNumber { Value = number });
                }
            }
        }
    }
}
