using System;
using System.Linq;

namespace _4._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().Split(", ").Select(double.Parse).Select(x => x * 1.2).ToArray();

            foreach(double price in prices)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
