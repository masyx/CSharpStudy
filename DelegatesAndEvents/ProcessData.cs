using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    class ProcessData
    {
        public void Process(int x, int y, BizRulesDelegate del) => Console.WriteLine($"\nProcess completed: {del(x, y)}".ToUpper());

        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            Console.WriteLine($"ProcessAction started:");
            action(x, y);
            Console.WriteLine($"ProcessAction completed:");
        }

        public void ProcessFunc(int x, int y, Func<int, int, int> func)
        {
            var result = func(x, y);
            Console.WriteLine($"ProcessFunc completed, result:{result}");
        }
         
    }
}
