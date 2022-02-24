using System;
using System.Linq;

namespace _2._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int numbersSum = GetSum(numbers);
            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbersSum);
        }

        private static int GetSum(int[] numbers)
        {
            int sum = 0;
            foreach(int number in numbers)
            {
                sum += number;
            }

            return sum;
        }
    }
}
