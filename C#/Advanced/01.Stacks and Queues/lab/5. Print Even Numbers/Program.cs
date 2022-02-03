using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> evenNumber = new Queue<int>();

            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                {
                    evenNumber.Enqueue(num);
                }
            }

            Console.WriteLine(string.Join(", ", evenNumber));
        }
    }
}
