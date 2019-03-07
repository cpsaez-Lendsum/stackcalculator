using System;
using System.Collections.Generic;
using System.Text;

namespace StackOperations.BasicOperations
{
    public class OperationMed : IStackItem, IStackOperation
    {
        public string Print => throw new NotImplementedException();

        public Stack<IStackItem> Eval(Stack<IStackItem> stack)
        {
            throw new NotImplementedException();
        }

        public IStackItem Parse(string raw)
        {
            throw new NotImplementedException();
        }
    }
}
