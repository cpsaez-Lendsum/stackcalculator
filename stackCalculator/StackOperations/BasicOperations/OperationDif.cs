using System;
using System.Collections.Generic;
using System.Text;

namespace StackOperations.BasicOperations
{
    public class OperationDif : IStackItem, IStackOperation
    {
        public string Print => throw new NotImplementedException();

        public Stack<IStackItem> Eval(Stack<IStackItem> stack)
        {
            // not enought parameters
            if (stack.Count < 2)
            {
                stack.Push(new Message() { Value = "Error, required at least 2 items" });
                return stack;
            }

            var value1 = stack.Pop();
            var value2 = stack.Pop();

            // happy path
            if ((value1 is IStackNumber parsedValue1) &&
                (value2 is IStackNumber parsedValue2))
            {
                var result = parsedValue2.Value - parsedValue1.Value;
                stack.Push(new IntegerNumber() { Value = result });
                return stack;
            }

            // error
            stack.Push(value2);
            stack.Push(value1);
            stack.Push(new Message() { Value = "First and second value must be a number" });
            return stack;
        }

        public IStackItem Parse(string raw)
        {
            if (raw == "-")
            {
                return this;
            }
            return null;
        }
    }
}
