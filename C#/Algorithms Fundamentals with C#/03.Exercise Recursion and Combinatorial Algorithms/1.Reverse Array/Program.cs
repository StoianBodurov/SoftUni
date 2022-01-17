using System;
using System.Linq;

namespace _0._3Recursion_and_Combinatorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            reversAray(numbers, numbers.Length - 1);
        }

        private static void reversAray(int[] numbers, int index)
        {
            if (index < 0)
            {
                return;
            }

            Console.Write(numbers[index] + " ");
            reversAray(numbers, index - 1);
            
        }
    }
}
