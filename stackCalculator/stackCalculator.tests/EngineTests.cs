using Moq;
using NUnit.Framework;
using StackOperations;
using StackOperations.BasicOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace stackCalculator.tests
{
    class EngineTests
    {
        Engine engine;
        List<Mock<IStackItem>> mockStackItems;

        [SetUp]
        public void Setup()
        {
            this.mockStackItems = new List<Mock<IStackItem>>();
        }

        [TestCase(new object[] { "14" }, new object[] { "2" , "3" , "2", "3", "max", "5", "6", "+", "+" })]
        [TestCase(new object[] { "11" }, new object[] { "5", "6", "+" })]
        [TestCase(new object[] { "5", "6" }, new object[] { "5", "6" })]
        [TestCase(new object[] { "5" }, new object[] { "5"})]
        public void EvalTest2(object[] expectedValues, object[] inputs)
        {
            MockEveryObject(inputs);
            this.engine = new Engine(mockStackItems.Select(x=> x.Object));

            EvalEngine(inputs);

            Assert.AreEqual(expectedValues.Length, engine.Current.Count);

            AssertStackValues(expectedValues);

        }

        private void AssertStackValues(object[] expectedValues)
        {
            var stack = this.engine.Current;
            var count = stack.Count;
            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(expectedValues[i], stack.Pop());
            }
        }

        private void EvalEngine(object[] inputs)
        {
            foreach(string input in inputs)
            {
                this.engine.Eval(input);
            }
        }

        private void MockEveryObject(object[] inputs)
        {
            foreach (string input in inputs) { 
                var mockStackItem = new Mock<IStackItem>();

                mockStackItem.Setup(x => x.Parse(It.IsAny<string>())).Returns((string value) => new IntegerNumber { Value = Int32.Parse(value) });

                mockStackItem.Setup(x => x.Parse(It.Is<string>((a) => a == "+" ))).Returns(new OperationSum());
                mockStackItem.Setup(x => x.Parse(It.Is<string>((a) => a == "max"))).Returns(new OperationMax());


                mockStackItem.Setup(x => x.Print).Returns(input);

                this.mockStackItems.Add(mockStackItem);
            }
        }
    }
}
