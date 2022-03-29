using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item22_128page
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new CelestialBody[3];
            result[0] = new Planet(2000, "Earth");
            result[1] = new Moon(500, "Moon");
            result[2] = new Asteroid(300, "Star");

            CelestialBody.CoVariantArray(result);
            CelestialBody.UnsafeVariantArray(result);

            CelestialBody[] spaceJunk = new CelestialBody[5];
            spaceJunk[0] = new Planet(50, "Trash");

            Console.WriteLine();

            List<Planet> planets = new List<Planet>();
            planets.Add(new Planet(5, "Mercury"));
            planets.Add(new Planet(700, "Jupiter"));
            planets.Add(new Planet(400, "Saturn"));

            CelestialBody.CovarantGeneric(planets);

            Console.ReadLine();
        }
    }

    abstract public class CelestialBody : IComparable<CelestialBody>
    {
        public double Mass { get; set; }
        public string Name { get; set; }

        public int CompareTo(CelestialBody other)
        {
            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// 안전하게 수행됨
        /// </summary>
        /// <param name="baseItems"></param>
        public static void CoVariantArray(CelestialBody[] baseItems)
        {
            foreach(var thing in baseItems)
            {
                Console.WriteLine($"{thing.Name} has a mass of {thing.Mass} kg");
            }
        }

        /// <summary>
        /// 예외를 일으킴(실제 실행은 잘 되는 것 같은디... 뭐지?)
        /// </summary>
        public static void UnsafeVariantArray(CelestialBody[] baseItems)
        {
            baseItems[0] = new Asteroid(8.85e19, "Hygiea");
        }

        public static void CovarantGeneric(IEnumerable<CelestialBody> baseItems)
        {
            foreach (var thing in baseItems)
                Console.WriteLine($"{thing.Name} has a mass of {thing.Mass} kg");
        }
    }

    public class Planet : CelestialBody
    {
        public Planet(double m, string n)
        {
            Mass = m;
            Name = n;
        }
    }

    public class Moon : CelestialBody
    {
        public Moon(double m, string n)
        {
            Mass = m;
            Name = n;
        }
    }

    public class Asteroid : CelestialBody
    {
        public Asteroid(double m, string n)
        {
            Mass = m;
            Name = n;
        }
    }
}