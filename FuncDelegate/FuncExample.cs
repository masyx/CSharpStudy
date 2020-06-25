using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FuncDelegate
{
    class FuncExample
    {
        static void Main(string[] args)
        {
            // EXAMPLE No.1

            // Declare a Func variable and assign a lambda expression to the
            // variable. The method takes a string a converts it to uppercase
            Func<string, string> selector = str => str.ToUpper();

            string[] wordss = { "orange", "apple", "Article", "elephant" };

            // Query the array and select strings according to the selector method.
            IEnumerable<string> aWordss = wordss.Select(selector);
            Console.WriteLine("\nEXAMPLE No.1");
            foreach (String word in aWordss)
                Console.WriteLine(word);




            // EXAMPLE No.2
            Func<string, int, bool> predicate = (str, index) => str.Length == index;

            string[] words = {"orange", "apple", "Article", "elephant", "star", "and"};
            IEnumerable<string> aWords = words.Where(predicate).Select(str => str);

            Console.WriteLine("\nEXAMPLE No.2");
            foreach (string word in aWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
