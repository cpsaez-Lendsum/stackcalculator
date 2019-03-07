using System;
using System.Collections.Generic;
using System.Text;

namespace StackOperations
{
    public class Message: IStackItem
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Parses the specified string and return the object that represent that string.
        /// </summary>
        /// <param name="raw">The raw.</param>
        /// <returns>
        /// null if the raw cannot be parsed by this type of item
        /// </returns>
        public IStackItem Parse(string raw)
        {
            return null;
        }

        /// <summary>
        /// Gets the print.
        /// </summary>
        /// <value>
        /// The print.
        /// </value>
        public string Print => Value;
    }
}
