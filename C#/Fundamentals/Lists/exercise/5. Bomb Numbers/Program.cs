using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> token = Console.ReadLine().Split().Select(int.Parse).ToList();

            int number = token[0];
            int power = token[1];

            while (numbers.Contains(number))
            {
                int index = numbers.IndexOf(number);

                int startIndex = index - power;
                if (startIndex <= 0)
                {
                    startIndex = 0;
                }

                int count = power * 2 + 1;
                if (startIndex + count >= numbers.Count())
                {
                    count = numbers.Count() - startIndex;
                }
                numbers.RemoveRange(startIndex, count);
                                
            }

            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}
