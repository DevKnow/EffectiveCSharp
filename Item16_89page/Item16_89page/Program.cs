using System;

namespace Item16_89page
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set by initializer가 출력됨
            var d = new Derived("Constructed in main");
        }
    }

    public class B
    {
        protected B()
        {
            VFunc();
        }

        protected virtual void VFunc()
        {
            Console.WriteLine("VFunc in B");
        }
    }

    public class Derived : B
    {
        private readonly string msg = "Set by initializer";

        public Derived(string msg)
        {
            this.msg = msg;
        }

        protected override void VFunc()
        {
            Console.WriteLine(msg);
        }
    }
}