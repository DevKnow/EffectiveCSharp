using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item20_121page
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public struct Customer : IComparable<Customer>, IComparable
    {
        private readonly string name;
        private double revenue;

        public Customer(string name, double revenue)
        {
            this.name = name;
            this.revenue = revenue;
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
            left.CompareTo(right) < 0;
        public static bool operator <=(Customer left, Customer right) =>
            left.CompareTo(right) <= 0;
        public static bool operator >(Customer left, Customer right) =>
            left.CompareTo(right) > 0;
        public static bool operator >=(Customer left, Customer right) =>
            left.CompareTo(right) >= 0;

        private static Lazy<RevenueComparer> revComp =
            new Lazy<RevenueComparer>(() => new RevenueComparer());

        public static IComparer<Customer> RevenueCompare => revComp.Value;

        public static Comparison<Customer> CompareByRevenue =>
            (left, right) => left.revenue.CompareTo(right.revenue);

        private class RevenueComparer : IComparer<Customer>
        {
            int IComparer<Customer>.Compare(Customer left, Customer right) =>
                left.revenue.CompareTo(right.revenue);
        }
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
