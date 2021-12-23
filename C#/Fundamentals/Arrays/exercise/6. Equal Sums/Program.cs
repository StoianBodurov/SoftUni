using System;
using System.Linq;

namespace _6._Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool notEqual = true;

            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                for (int j = 0; j <= i; j++)
                {
                    leftSum += numbers[j];
                }
                for (int j = i; j < numbers.Length; j++)
                {
                    rightSum += numbers[j];
                }
                if (leftSum == rightSum)
                {
                    notEqual = false;
                    Console.WriteLine(i);
                }
            }

            if (notEqual)
            {
                Console.WriteLine("no");
            }
            {

            }
        }
    }
}
