using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Item1_18page
{
    public class DB
    {
        public List<CustomerInfo> Customers;

        public DB()
        {
            Customers = new List<CustomerInfo>();
        }

        public void Init()
        {
            Customers.Add(new CustomerInfo("김민지", "010-444-444"));
            Customers.Add(new CustomerInfo("이은비", "010-555-555"));
            Customers.Add(new CustomerInfo("빅육육", "010-666-666"));
            Customers.Add(new CustomerInfo("김칠팔", "010-777-888"));
        }
    }

    public class CustomerInfo
    {
        public string ContactName;
        public string ContactNumber;

        public CustomerInfo(string name, string number)
        {
            ContactName = name;
            ContactNumber = number;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var foo = new MyType();

            AccountFactory factory = new AccountFactory();
            var thing = factory.CreateSavingsAccount();

            var f = foo.GetMagicNumber();
            var total = 100 * f / 6;
            // Console.WriteLine($"Declared Type: {total.GetType().Name}, Value: {total}");

            var test = new DB();
            test.Init();

            var list = foo.FindCustomersStartingWith(test, "김");

            foreach(var c in list)
            {
                Console.WriteLine(c);
            }
        }
    }

    public class MyType
    {
        public double GetMagicNumber()
        {
            return 10.0;
        }

        public IEnumerable<string> FindCustomersStartingWith(DB db, string start)
        {
            var q =
                from c in db.Customers
                select c.ContactName;

            var q2 = q.Where(s => s.StartsWith(start));

            return q2;
        }
    }

    // 팩토리 메소드 확인용
    public class AccountFactory
    {
        public SavingsAccount CreateSavingsAccount()
        {
            return new SavingsAccount();
        }
    }

    // 팩토리 메소드 확인용
    public class SavingsAccount
    {
        
    }
}