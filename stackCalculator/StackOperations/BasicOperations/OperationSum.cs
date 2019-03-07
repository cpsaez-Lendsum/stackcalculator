using System;
using System.Collections.Generic;
using System.Text;

namespace StackOperations.BasicOperations
{
    public class OperationSum : IStackItem, IStackOperation
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
            if (raw == "+")
            {
                return this;
            }

            return null;
        }

        public string Print => "+";

        /// <summary>
        /// Evals the specified stack.
        /// </summary>
        /// <param name="stack">The stack.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Stack<IStackItem> Eval(Stack<IStackItem> stack)
        {
            // not enought parameters
            if (stack.Count < 2)
            {
                stack.Push(new Message() {Value = "Error, required at least 2 items"});
                return stack;
            }

            var value1 = stack.Pop();
            var value2 = stack.Pop();

            // happy path
            if ((value1 is IStackNumber parsedValue1) &&
                (value2 is IStackNumber parsedValue2))
            {
                var result = parsedValue1.Value + parsedValue2.Value;
                stack.Push(new IntegerNumber() {Value = result});
                return stack;
            }

            // error
            stack.Push(value2);
            stack.Push(value1);
            stack.Push(new Message() {Value = "First and second value must be a number"});
            return stack;
        }
    }
}
