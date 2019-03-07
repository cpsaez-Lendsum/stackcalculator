using System;
using System.Collections.Generic;
using System.Text;

namespace StackOperations
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStackItem
    {
        /// <summary>
        /// Parses the specified string and return the object that represent that string.
        /// </summary>
        /// <param name="raw">The raw.</param>
        /// <returns>null if the raw cannot be parsed by this type of item</returns>
        IStackItem Parse(string raw);

        /// <summary>
        /// Gets the print.
        /// </summary>
        /// <value>
        /// The print.
        /// </value>
        string Print { get; }
    }
}
