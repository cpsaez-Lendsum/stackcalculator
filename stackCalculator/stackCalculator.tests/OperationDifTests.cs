using NUnit.Framework;
using StackOperations;
using StackOperations.BasicOperations;
using System.Collections.Generic;

namespace stackCalculator.tests
{
    class OperationDifTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EvalTest()
        {
            var operationDif = new OperationDif();
            var stack = new Stack<IStackItem>();

            stack.Push(new IntegerNumber { Value = 5 });
            stack.Push(new IntegerNumber { Value = 4 });
            var result = operationDif.Eval(stack);

            Assert.AreEqual(1, (result.Pop() as IntegerNumber).Value);
            
            Assert.Pass();
        }
    }
}
