using System;
using System.Collections.Generic;

namespace _4._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < count; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(num))
                {
                    numbers.Add(num, 0);
                }
                numbers[num] += 1;
            }

            foreach(var keyValue in numbers)
            {
                if (keyValue.Value % 2 == 0)
                {
                    Console.WriteLine(keyValue.Key);
                    break;
                }
            }
        }
    }
}
