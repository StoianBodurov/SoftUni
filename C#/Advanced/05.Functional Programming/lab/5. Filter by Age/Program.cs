using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> persons = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(", ");
                string name = data[0];
                int age = int.Parse(data[1]);
                persons[name] = age;
            }

            string condition = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            Func<int, bool> tester = CreateTeater(condition, filterAge);
            string format = Console.ReadLine();


            var filteredPersons = persons.Where(x => tester(x.Value));

            PrintFilteredPreson(format, filteredPersons);
            

        }

        private static void PrintFilteredPreson(string format, IEnumerable<KeyValuePair<string, int>> persons)
        {
            switch (format)
            {
                case "name":
                    foreach(var person in persons)
                    {
                        Console.WriteLine($"{person.Key}");
                    }
                    return;
                case "age":
                    foreach (var person in persons)
                    {
                        Console.WriteLine($"{person.Value}");
                    }
                    return;
                case "name age":
                    foreach (var person in persons)
                    {
                        Console.WriteLine($"{person.Key} - {person.Value}");
                    }
                    return;
            }
        }

        private static Func<int, bool> CreateTeater(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                        return x => x < age;
                case "older":
                    return x => x >= age;
                default:
                    return null;

            }
        }
    }
}
