using System.Collections.Generic;
using System.Linq;

namespace StackOperations
{
    /// <summary>
    /// Stack calculator engine
    /// </summary>
    public class Engine
    {
        private readonly IEnumerable<IStackItem> allowedItems;
        private Stack<IStackItem> items;

        public Stack<string> Current
        {
            get
            {
                Stack<string> result = new Stack<string>();
                IEnumerable<string> values = items.ToArray().Select(x => x.Print);
                foreach (string raw in values)
                {
                    result.Push(raw);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Engine"/> class.
        /// </summary>
        /// <param name="allowedItems">The allowed items.</param>
        public Engine(IEnumerable<IStackItem> allowedItems)
        {
            this.allowedItems = allowedItems;
            Reset();
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            this.items = new Stack<IStackItem>();
        }

        /// <summary>
        /// Evals the specified raw.
        /// </summary>
        /// <param name="raw">The raw.</param>
        public void Eval(string raw)
        {
            foreach (var item in allowedItems)
            {
                var newItem = item.Parse(raw);
                if (newItem != null)
                {
                    items.Push(newItem);
                    return;
                }
            }

            if (items.Peek() is IStackOperation operation)
            {
                items.Pop();
                this.items=operation.Eval(items);
            }
        }
    }
}
