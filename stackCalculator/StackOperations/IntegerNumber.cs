using System;
using System.Collections.Generic;
using System.Text;

namespace StackOperations
{
    /// <summary>
    /// An integer number
    /// </summary>
    /// <seealso cref="StackOperations.IStackItem" />
    public class IntegerNumber : IStackItem, IStackNumber
    {
        public int Value { get;  set; }

        /// <summary>
        /// Parses the specified string and return the object that represent that string.
        /// </summary>
        /// <param name="raw">The raw.</param>
        /// <returns>
        /// null if the raw cannot be parsed by this type of item
        /// </returns>
        public IStackItem Parse(string raw)
        {
            if (int.TryParse(raw,out var value ))
            {
                return new IntegerNumber() {Value = value};
            }

            return null;
        }

        public string Print => Value.ToString();
    }
}
