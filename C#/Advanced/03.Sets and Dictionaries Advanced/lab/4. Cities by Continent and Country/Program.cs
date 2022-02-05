using System;
using System.Collections.Generic;

namespace _4._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string continent = data[0];
                string countrie = data[1];
                string sity = data[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continents[continent].ContainsKey(countrie))
                {
                    continents[continent].Add(countrie, new List<string>());
                }

                continents[continent][countrie].Add(sity);
            }

            foreach(var pair in continents)
            {
                Console.WriteLine($"{pair.Key}:");

                foreach(var p in pair.Value)
                {
                    Console.WriteLine($"  {p.Key} -> {string.Join(", ", p.Value)}");
                }
            }

        }
    }
}
