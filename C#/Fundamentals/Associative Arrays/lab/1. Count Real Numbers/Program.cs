using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SortedDictionary<int, int> countDict = new SortedDictionary<int, int>();

            foreach (var num in numbers)
            {
                if (!countDict.ContainsKey(num))
                {
                    countDict.Add(num, 0); 
                }

                countDict[num] += 1;
            }

            foreach (var item in countDict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
