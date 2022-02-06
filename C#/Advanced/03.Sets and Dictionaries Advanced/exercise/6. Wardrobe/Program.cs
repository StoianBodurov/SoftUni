using System;
using System.Collections.Generic;

namespace _6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" -> ");
                string color = data[0];
                string[] clothes = data[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach(string clothe in clothes)
                {
                    if (!wardrobe[color].ContainsKey(clothe))
                    {
                        wardrobe[color].Add(clothe, 0);
                    }
                    wardrobe[color][clothe] += 1;
                }
            }
            string[] searchCriteria = Console.ReadLine().Split();
            string searchColor = searchCriteria[0];
            string searchClothing = searchCriteria[1];

            foreach (var keyValue in wardrobe)
            {
                bool isColor = false;
                if (keyValue.Key == searchColor)
                {
                    isColor = true;
                }
                
                Console.WriteLine($"{keyValue.Key} clothes");
                foreach(var kv in keyValue.Value)
                {
                    if (isColor && kv.Key == searchClothing)
                    {
                        Console.WriteLine($" * {kv.Key} - {kv.Value} (found!)");

                    }
                    else
                    {
                        Console.WriteLine($" * {kv.Key} - {kv.Value}");
                    }
                }
            }
        }
    }
}
