using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();

            int halfCount = numbers.Count() / 2;

            for (int i = 0; i < halfCount; i++)
            {
                int sum = numbers[i] + numbers[numbers.Count() - 1 - i];
                result.Add(sum);
            }
            if (numbers.Count % 2 != 0)
            {
                result.Add(numbers[halfCount]);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
