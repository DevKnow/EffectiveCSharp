using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Item2_25page
{
    class Program
    {
        static readonly YearList meme1 = new YearList(1,2,3);
        static readonly YearList meme2 = new YearList(500, 3, 4);

        static void Main(string[] args)
        {
            meme1.Print();
            meme2.Print();

            if (DateTime.Now.Year.Equals(YearList.Millenium))
                Console.WriteLine("현재는 밀레니엄!");

            if (DateTime.Now.Year.Equals(YearList.ThisYear))
                Console.WriteLine("현재는 2022년!");
        }
    }

    public class YearList
    {
        // 컴파일 상수
        public const int Millenium = 2000;

        // 런타임 상수
        public static readonly int ThisYear = 2022;

        int a, b, c;

        public YearList(int one, int two, int three)
        {
            a = one;
            b = two;
            c = three;
        }

        public void Print()
        {
            Console.Write(a+" ");
            Console.Write(b + " ");
            Console.WriteLine(c);
        }
    }
}
