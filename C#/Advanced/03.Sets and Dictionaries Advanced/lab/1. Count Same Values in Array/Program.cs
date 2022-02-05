using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> countDouble = new Dictionary<double, int>();

            foreach (double el in array)
            {
                if (!countDouble.ContainsKey(el))
                {
                    countDouble.Add(el, 0);
                }
                countDouble[el] += 1;
            }

            foreach (var pair in countDouble)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
