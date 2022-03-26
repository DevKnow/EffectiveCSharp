using System;
using System.Text;

namespace Item15_88page
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder msg = new StringBuilder("Hello, ");

            msg.Append("thisUser.Name");
            msg.Append(". Today is ");
            msg.Append(DateTime.Now.ToString());

            string finalMsg = msg.ToString();

            Console.WriteLine(finalMsg);
        }
    }
}