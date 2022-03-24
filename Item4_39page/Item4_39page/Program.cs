using System;
using System.Collections.Generic;
using System.Linq;

namespace Item4_39page
{
    class Program
    {
        static void Main(string[] args)
        {
            bool round = true;
            Console.WriteLine($"The value of pi is {(round ? Math.PI.ToString() : Math.PI.ToString("F2"))}");

            //////////////////////////////////////////

            Customer c = new Customer();
            Console.WriteLine($"The customer's name is {c?.Name ?? "Name is Missing"}");

            //////////////////////////////////////////

            Dictionary<int, string> records = new Dictionary<int, string>();
            records.Add(15, "심심");
            records.Add(2, "졸려");
            records.Add(5, "수면");

            int index = 0;
            string result = default(string);
            Console.WriteLine($@"Record is {(records.TryGetValue(index, out result) ? result : $"No record found at index {index}")}");

            //////////////////////////////////////////

            Customer src = new Customer();
            var output = $@"The First five items are{src.Take(5).Select(
                n=>$@"Items: {n.ToString()}").Aggregate(
                (c,a) => $@"{c}{Environment.NewLine}{a}")}";

            foreach (var ch in output)
                Console.Write($"{ch}");

            //////////////////////////////////////////
            

        }

        internal class Customer
        {
            public string Name = "사람이름";

            public List<int> Take(int value)
            {
                List<int> temp = new List<int>();
                for (int i = 0; i < value; i++)
                    temp.Add(i);

                return temp;
            }
        }
    }
}