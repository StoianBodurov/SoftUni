using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] data = Console.ReadLine().Split().Select(double.Parse).ToArray();

            List<int> result = new List<int>();

            double average = data.Sum() / data.Length;
            
            foreach (var el in data)
            {
                if (el > average)
                {
                    result.Add((int)el);
                }
            }

            result.Sort((x, y) => y.CompareTo(x));
            if (result.Count > 0)
            {
                if (result.Count > 5)
                {
                    result = result.GetRange(0, 5);
                }
                Console.WriteLine(string.Join(" ", result));
            }
            else
            {
                Console.WriteLine("No");
            }
            
        }
    }
}
