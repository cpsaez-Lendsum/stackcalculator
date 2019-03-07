using System;
using System.Collections.Generic;
using System.Text;

namespace StackOperations.BasicOperations
{
    public class OperationDel : IStackItem, IStackOperation
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
            if (raw == "del")
            {
                return this;
            }

            return null;
        }

        public string Print => "del";

        /// <summary>
        /// Evals the specified stack.
        /// </summary>
        /// <param name="stack">The stack.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Stack<IStackItem> Eval(Stack<IStackItem> stack)
        {
            // not enought parameters
            if (stack.Count < 1)
            {
                stack.Push(new Message() { Value = "Error, required at least 1 items" });
                return stack;
            }

            var lastValue = stack.Pop();

            // happy path
            if (lastValue is IStackNumber parsedLastValue)
            {
                stack.Push(new Message() { Value = "Deleted " + lastValue });
                return stack;
            }


            stack.Push(new Message() { Value = "The value must be a number" });
            return stack;
        }

    }
}
