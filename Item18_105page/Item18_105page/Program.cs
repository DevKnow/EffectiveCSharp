using System;
using System.Collections.Generic;

namespace Item18_105page
{
    class Program
    {
        static void Main(string[] args)
        {
            int? a=null, b=null;
            string astring = "", bstring = "아이스크림 먹고 싶다";
            Console.WriteLine(AreEqual<int?>(a, b));
            Console.WriteLine(AreEqual2<string>(astring, bstring));

            Console.WriteLine("//////////////////////////////////////");

            List<string> someDatas = new List<string>();
            someDatas.Add("안녕");
            someDatas.Add("와");
            someDatas.Add("와 졸려");
            Console.WriteLine(someDatas.FirstOrDefaultMake<string>(s => s.Contains("와")));   
        }

        public static bool AreEqual<T>(T left, T right)
        {
            if (left == null) return right == null;

            if (left is IComparable<T>)
            {
                IComparable<T> lval = left as IComparable<T>;
                if (right is IComparable<T>)
                    return lval.CompareTo(right) == 0;
                else
                    throw new ArgumentException("Type does not implement ICompareable<T>",
                        nameof(right));
            }
            else
            {
                throw new ArgumentException("Type does not implement ICompareable<T>",
                        nameof(left));
            }
        }

        public static bool AreEqual2<T>(T left, T right)
            where T : IComparable<T> =>
                left.CompareTo(right) == 0;

    }

    public static class Something
    {
        public static T FirstOrDefaultMake<T>(this IEnumerable<T> sequence, Predicate<T> test)
        {
            foreach (T value in sequence)
            {
                if (test(value)) return value;
            }
            return default(T);
        }
    }

    public class InstanceFactory<T>
    {
        public delegate T FactoryFunc<T>();

        public static T Factory<T>(FactoryFunc<T> makeANewT) where T : new()
        {
            T rVal = makeANewT();
            if (rVal == null) return new T();
            else return rVal;
        }
    }
}