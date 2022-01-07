using System;
using System.Collections.Generic;

namespace _4._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> ordersPrice = new Dictionary<string, double>();
            Dictionary<string, int> ordersQuantity = new Dictionary<string, int>();

            while (true)
            {
                string[] token = Console.ReadLine().Split();

                if (token[0] == "buy")
                {
                    break;
                }

                string product = token[0];
                double price = double.Parse(token[1]);
                int quantity = int.Parse(token[2]);

                if (!ordersPrice.ContainsKey(product))
                {
                    ordersPrice.Add(product, 0);
                    ordersQuantity.Add(product, 0);
                }

                ordersPrice[product] = price;
                ordersQuantity[product] += quantity;
            }

            foreach (var item in ordersPrice)
            {
                Console.WriteLine($"{item.Key} -> {item.Value * ordersQuantity[item.Key]:f2}");
            }
        }
    }
}
