using System;
using System.Linq;
using System.Collections.Generic;

namespace Item7_48page
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Enumerable.Range(1, 200).ToList();

            var oddNumbers = numbers.Find(n => (n % 2).Equals(1));
            var test = numbers.TrueForAll(n => n < 50);

            test = numbers.TrueForAll(n => (n % 2).Equals(1));
            Console.WriteLine(test);

            numbers.RemoveAll(n => (n % 2).Equals(0));
            numbers.ForEach(item => Console.WriteLine(item));

            test = numbers.TrueForAll(n => (n % 2).Equals(1));
            Console.WriteLine(test);
        }
    }
}
