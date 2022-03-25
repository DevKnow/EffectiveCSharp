using System;

namespace Item5_43page
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = $"It's the {DateTime.Now.Day} of {DateTime.Now.Month} month";
            Console.WriteLine(first);

            FormattableString second = $"It's the {DateTime.Now.Day} of {DateTime.Now.Month} month";
            Console.WriteLine(second);

            var typeCheck = $"It's the {DateTime.Now.Day} of {DateTime.Now.Month} month";

            //Console.WriteLine(ToGerman($"German: {DateTime.Now.Date}"));
            //Console.WriteLine(ToFrenchCanada($"FrenchCanada: {DateTime.Now.Date}"));
        }

        public static string ToGerman(FormattableString src)
        {
            return string.Format(null,
                System.Globalization.CultureInfo.CreateSpecificCulture("de-de"),
                src.Format, src.GetArguments());
        }

        public static string ToFrenchCanada(FormattableString src)
        {
            return string.Format(null,
                System.Globalization.CultureInfo.CreateSpecificCulture("fr-CA"),
                src.Format, src.GetArguments());
        }
    }
}