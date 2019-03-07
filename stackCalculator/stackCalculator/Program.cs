using StackOperations;
using StackOperations.BasicOperations;
using System;

namespace stackCalculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Engine engine = InitEngine();
            Console.WriteLine("Stack Calculator ready");
            while (true)
            {
                string raw = Console.ReadLine();
                engine.Eval(raw);
                Console.Clear();
                var current = engine.Current;
                while (current.Count > 0)
                {
                    Console.WriteLine(current.Pop());
                }
            }
        }

        private static Engine InitEngine()
        {
            IStackItem[] items = new IStackItem[]
            {
                    new IntegerNumber(),
                    new OperationSum()
            };

            return new Engine(items);
        }
    }
}
