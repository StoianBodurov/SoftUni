using System;
using System.Linq;

namespace _2._Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int index = 0; index < numbers.Length; index++)
            {
                int min = index;
                for (int current = index + 1; current < numbers.Length; current++)
                {
                    if (numbers[current] < numbers[min])
                    {
                        min = current;
                    }
                }

                Swap(numbers, index, min);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Swap(int[] numbers, int index, int min)
        {
            int temp = numbers[min];
            numbers[min] = numbers[index];
            numbers[index] = temp;
        }
    }
}
