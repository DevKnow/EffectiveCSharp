using System;

namespace Item10_58page
{
    class Program
    {
        static void Main(string[] args)
        {
            object c = MakeObject();

            MyClass cl = c as MyClass;
            cl?.MagicMethod();

            MyOtherClass cl2 = c as MyOtherClass;
            cl2?.MagicMethod();
        }

        public static object MakeObject()
        {
            return new object();
        }
    }

    public class MyClass : Object
    {
        public void MagicMethod()
        {
            Console.WriteLine("MyClass 클래스의 MagicMethod() 호출합니다");
        }
    }

    public class MyOtherClass : MyClass
    {
        public new void MagicMethod()
        {
            Console.WriteLine("MyOtherClass 클래스의 MagicMethod() 호출합니다");
        }
    }
}