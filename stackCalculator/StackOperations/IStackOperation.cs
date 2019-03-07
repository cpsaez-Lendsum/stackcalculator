using System;
using System.Collections.Generic;
using System.Text;

namespace StackOperations
{
    /// <summary>
    /// Interface to represent a stack operation
    /// </summary>
    public interface IStackOperation
    {
        /// <summary>
        /// Evals the specified stack.
        /// </summary>
        /// <param name="stack">The stack.</param>
        /// <returns></returns>
        Stack<IStackItem> Eval(Stack<IStackItem> stack);
    }
}
