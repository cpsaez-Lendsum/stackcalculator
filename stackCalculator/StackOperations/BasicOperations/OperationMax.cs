using System;
using System.Collections.Generic;
using System.Text;

namespace StackOperations.BasicOperations
{
    public class OperationMax : IStackItem, IStackOperation
    {

        /// <summary>
        /// Parses the specified string and return the object that represent that string.
        /// </summary>
        /// <param name="raw">The raw.</param>
        /// <returns>
        /// null if the raw cannot be parsed by this type of item
        /// </returns>
        public IStackItem Parse(string raw)
        {
            if (raw == "max")
            {
                return this;
            }

            return null;
        }

        public string Print => "max";

        /// <summary>
        /// Evals the specified stack.
        /// </summary>
        /// <param name="stack">The stack.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Stack<IStackItem> Eval(Stack<IStackItem> stack)
        {
            if (stack.Count < 2)
            {
                stack.Push(new Message() { Value = "Error, required at least 2 items" });
                return stack;
            }
            var firstItem = stack.Pop();
            if (!(firstItem is IntegerNumber))
            {
                stack.Push(new Message() { Value = "Error, the first value is not an integer " + firstItem });
                return stack;
            }

            var firstIntegerItem = (firstItem as IntegerNumber).Value;

            if (firstIntegerItem < 0)
            {
                stack.Push(new Message() { Value = "The range cannot be negative: " + firstIntegerItem });
                return stack;
            }

            var max = 0;
            for (int i = 0; i < firstIntegerItem; i++)
            {
                var act = stack.Pop();
                if (!(act is IntegerNumber))
                {
                    stack.Push(new Message() { Value = "Error there is something that there is not a number " + act });
                    return stack;
                }
                var actNum = (act as IntegerNumber).Value;
                max = max > actNum ? max : actNum;
            }

            stack.Push(new IntegerNumber { Value = max });

            return stack;

        }

    }
}
