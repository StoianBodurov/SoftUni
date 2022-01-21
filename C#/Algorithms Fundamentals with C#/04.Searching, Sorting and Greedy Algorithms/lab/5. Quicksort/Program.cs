using System;
using System.Linq;

namespace _5._Quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Quicksort(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Quicksort(int[] numbers, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int pivotIndex = startIndex;
            int leftIndex = startIndex + 1;
            int rightIndex = endIndex;

            while (leftIndex <= rightIndex)
            {
                if (numbers[leftIndex] > numbers[pivotIndex] && numbers[rightIndex] < numbers[pivotIndex])
                {
                    Swap(numbers, leftIndex, rightIndex);
                }

                if (numbers[leftIndex] <= numbers[pivotIndex])
                {
                    leftIndex += 1;
                }

                if (numbers[rightIndex] >= numbers[pivotIndex])
                {
                    rightIndex -= 1;
                }
            }

            Swap(numbers, pivotIndex, rightIndex);

            var isLeftSubArrayIsSmaller = rightIndex - 1 - startIndex < endIndex - (rightIndex + 1);
            if (isLeftSubArrayIsSmaller)
            {
                Quicksort(numbers, startIndex, rightIndex - 1);
                Quicksort(numbers, rightIndex + 1, endIndex);
            }
            else
            {
                Quicksort(numbers, rightIndex + 1, endIndex);
                Quicksort(numbers, startIndex, rightIndex - 1);


            }
        }

        private static void Swap(int[] numbers, int start, int end)
        {
            int temp = numbers[start];
            numbers[start] = numbers[end];
            numbers[end] = temp;
        }
    }
}
