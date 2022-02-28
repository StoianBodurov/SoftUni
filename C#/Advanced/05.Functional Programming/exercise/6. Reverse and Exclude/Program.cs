using System;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            Predicate<int> checker = n => GetNumbers(number, n);

            int[] result = data.Split(" ").Select(int.Parse).Where(n => checker(n)).ToArray();

            Console.WriteLine(string.Join(" ", result.Reverse()));
        }

        private static bool GetNumbers(int number, int n)
        {
            return n % number != 0;
        }
    }
}
