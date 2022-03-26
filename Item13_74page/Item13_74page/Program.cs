using System;

namespace Item13_74page
{
    class Program
    {
        static void Main(string[] args)
        {
            MySingleton2.Print();
        }
    }

    public class MySingleton2
    {
        private static readonly MySingleton2 theOneAndOnly;

        static MySingleton2()
        {
            Console.WriteLine("static 생성자 호출됨");
            //theOneAndOnly = new MySingleton2();

            try
            {
                theOneAndOnly = new MySingleton2();
            }
            catch
            {
                // 복구 시도
            }
        }

        public static MySingleton2 TheOnly
        {
            get { return theOneAndOnly; }
        }

        private MySingleton2()
        {
            Console.WriteLine("private 생성자 호출됨");
        }

        public static void Print()
        {
            Console.WriteLine("출력합니다");
        }
    }
}