using System;
using System.Collections.Generic;

namespace Item9_55page
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = 1, second = 2, third = 3;
            Console.WriteLine($"A few numbers: {first.ToString()} {second.ToString()} {third.ToString()}");

            var attendees = new List<Person>();
            Person p = new Person { Name = "Old Name" };
            attendees.Add(p);

            Person p2 = attendees[0];
            p2.Name = "New Name"; // 변경되지 않음

            foreach (var inside in attendees)
                Console.WriteLine(inside.Name);
        }
    }

    public struct Person
    {
        public string Name;
    }
}