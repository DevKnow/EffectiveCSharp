using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            Print("////////////////////////////");

            double[] xValues =
            {
                0,1,2,3,4,5,6,7,8,9,
                0,1,2,3,4,5,6,7,8,9
            };

            double[] yValues =
{
                0,1,2,3,4,5,6,7,8,9,
                0,1,2,3,4,5,6,7,8,9
            };

            List<Point> values = new List<Point>(
                Utilities.Zip(xValues, yValues, (x, y) =>
                    new Point(x, y)));

            Console.ReadKey();
        }

        public static T Add<T>(T left, T right, Func<T, T, T> AddFunc) =>
            AddFunc(left, right);

        public static void Print(string str) => Console.WriteLine(str);

        public static int Sum(int a, int b) => a + b;
    }

   public class Point
    {
        public double X;

        public double Y;

        delegate TOutput Func<T1, T2, TOutput>(T1 arg1, T2 arg2);

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class Utilities
    {
        public static IEnumerable<TOutput> Zip<T1, T2, TOutput>(
            IEnumerable<T1> left, IEnumerable<T2> right,
            Func<T1, T2, TOutput> generator)
        {
            IEnumerator<T1> leftSequence = left.GetEnumerator();
            IEnumerator<T2> rightSequence = right.GetEnumerator();

            while (leftSequence.MoveNext() && rightSequence.MoveNext())
            {
                yield return generator(leftSequence.Current, rightSequence.Current);
            }

            leftSequence.Dispose();
            rightSequence.Dispose();
        }
    }
}
