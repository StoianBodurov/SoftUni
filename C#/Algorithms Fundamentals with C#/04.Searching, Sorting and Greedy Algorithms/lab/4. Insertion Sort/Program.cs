using System;
using System.Linq;

namespace _4._Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 1; i < numbers.Length; i++)
            {
                int j = i;

                while (j > 0 && numbers[j] < numbers[j - 1])
                {
                    Swap(numbers, j, j - 1);
                    j--;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Swap(int[] numbers, int j, int v)
        {
            int temp = numbers[j];
            numbers[j] = numbers[v];
            numbers[v] = temp;
        }
    }
}
