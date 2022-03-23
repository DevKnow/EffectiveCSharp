using System;

namespace Item3_30page
{
    class Program
    {
        static void Main(string[] args)
        {
            object o = Factory.GetObject();
            //MyType t = o as MyType;

            //if (t != null) t.Hello();
            //else Console.WriteLine("Error!");

            try
            {
                MyType t = (MyType)o;
                if (t != null) t.Hello();
                else throw new Exception("t가 비어있습니다.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: "+ e.Message);
            }
        }
    }


    public class MyType
    {
        public void Hello()
        {
            Console.WriteLine("안녕");
        }
    }

    public class Factory
    {
        public static int GetObject()
        {
            return 3;
        }
    }
}
