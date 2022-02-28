using System;
using System.Linq;

namespace _8._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Array.Sort(numbers, (x, y) => MyCompare(x, y));

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int MyCompare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }

            if(x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }

            return 0;


        }
    }
}
