using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item23_134page
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 6, b = 7;
            Console.WriteLine((Add(a, b, (x, y) => x + y)).ToString());

            Print("안녕하세요안녕하세요안녕하세요");
            Console.WriteLine(Sum(a, b+3).ToString());

            Console.ReadKey();
        }

        public static T Add<T>(T left, T right, Func<T, T, T> AddFunc) =>
            AddFunc(left, right);

        public static void Print(string str) => Console.WriteLine(str);

        public static int Sum(int a, int b) => a + b;
    }
}
