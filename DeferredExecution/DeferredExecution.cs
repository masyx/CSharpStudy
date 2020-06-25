using System;
using System.Collections.Generic;
using System.Linq;

namespace DeferredExecution
{
    class DeferredExecution
    {
        static void Main(string[] args)
        {
            var list1 = new List<int>() { 1, 2, 3, 4 };

            // call method ToList() here to have the same output in foreach loops
            // When you call ToList() you are avoiding deferred execution
            var result = list1.Where(i => i > 3);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            list1.Add(5);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
