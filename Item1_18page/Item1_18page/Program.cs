using System;

namespace Item1_18page
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new MyType();

            AccountFactory factory = new AccountFactory();
            var thing = factory.CreateSavingsAccount();

            var f = foo.GetMagicNumber();
            var total = 100 * f / 6;
            Console.WriteLine($"Declared Type: {total.GetType().Name}, Value: {total}");
        }
    }

    public class MyType
    {
        public double GetMagicNumber()
        {
            return 10.0;
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