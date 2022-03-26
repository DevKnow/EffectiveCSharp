using System;
using System.Collections.Generic;

namespace Item14_76page
{
    class Program
    {
        static void Main(string[] args)
        {
            var something = new MyClass(5);
        }
    }

    public class MyClass
    {
        private List<ImportanceData> coll;
        private string name;

        /*
        public MyClass() : this(0, "")
        {

        }

        
        public MyClass(int initialCount) :
            this(initialCount, string.Empty)
        {

        }
        */

        public MyClass() : this(0,string.Empty)
        {

        }

        public MyClass(int initialCount=0, string name="")
        {
            coll = (initialCount > 0) ?
                new List<ImportanceData>(initialCount) :
                new List<ImportanceData>();

            this.name = name;
        }
    }

    public class ImportanceData
    {

    }

}
