using System;

namespace Item6_46page
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                object? a=null;
                ExceptionMessgae(a);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ExceptionMessgae(object thisCantBeNull)
        {
            if(thisCantBeNull==null)
                throw new ArgumentNullException(nameof(thisCantBeNull), "We told you this cant be null");
        }
    }
}
