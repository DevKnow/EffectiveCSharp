using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace Item20_118page
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1=new Customer("김식물이");
            Employee e1 = new Employee("김식물이 2세");

            if (((IComparable)c1).CompareTo(e1) > 0)
                Console.WriteLine("Customer one is greater");
        }
    }

    public struct Customer : IComparable<Customer>, IComparable
    {
        private readonly string name;

        public Customer(string name)
        {
            this.name = name;
        }

        // IComparable<T> 멤버
        public int CompareTo(Customer other) => name.CompareTo(other.name);

        // IComparable 멤버
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Customer))
                throw new ArgumentException("Argument is not a Customer", "obj");
            Customer otherCustomer = (Customer)obj;

            return this.CompareTo(otherCustomer);
        }

        public static bool operator <(Customer left, Customer right) =>
            left.CompareTo(right)<0;
        public static bool operator <=(Customer left, Customer right) =>
            left.CompareTo(right) <= 0;
        public static bool operator >(Customer left, Customer right) =>
            left.CompareTo(right) > 0;
        public static bool operator >=(Customer left, Customer right) =>
            left.CompareTo(right) >= 0;

        //public static Comparison<Customer> CompareByRevenue =>
        //    (left, right) => left.revenue.CompareTo(right.revenue);
    }

    public struct Employee
    {
        private readonly string name;

        public Employee(string name)
        {
            this.name = name;
        }
    }
}
