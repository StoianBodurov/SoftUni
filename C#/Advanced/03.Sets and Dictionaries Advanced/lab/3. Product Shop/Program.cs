using System;
using System.Collections.Generic;

namespace _3._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] token = Console.ReadLine().Split(", ");
                string command = token[0];

                if (command == "Revision")
                {
                    break;
                }
                string shop = token[0];
                string product = token[1];
                double price = double.Parse(token[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }
                shops[shop].Add(product, price);
            }

            foreach(var pair in shops)
            {
                Console.WriteLine($"{pair.Key}->");
                foreach(var p in pair.Value)
                {
                    Console.WriteLine($"Product: {p.Key}, Price: {p.Value}");
                }
            }
        }
    }
}
