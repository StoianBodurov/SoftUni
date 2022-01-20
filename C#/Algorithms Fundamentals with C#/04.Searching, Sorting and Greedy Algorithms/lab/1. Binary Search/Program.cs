using System;
using System.Linq;

namespace _1._Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int searchNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(numbers, searchNumber));
        }

        private static int BinarySearch(int[] numbers, int searchNumber)
        {
            int start = 0;
            int end = numbers.Length - 1;

            while (start <= end)
            {

                int mid = (end + start) / 2;

                if (numbers[mid] == searchNumber)
                {
                    return mid;
                }

                if (numbers[mid] < searchNumber)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            return -1;
        }
    }
}
