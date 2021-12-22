using System;
using System.Linq;

namespace _4._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numberOfRotatin = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRotatin; i ++)
            {
                int tempElement = numbers[0];
                for (int j = 1; j < numbers.Length; j++)
                {
                    numbers[j - 1] = numbers[j];
                }
                numbers[numbers.Length - 1] = tempElement;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
