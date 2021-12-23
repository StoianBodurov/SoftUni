using System;
using System.Linq;

namespace _7._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxSecuence = 0;
            int element = numbers[0];
            int currentSecuence = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    currentSecuence += 1;
                }
                else
                {
                    currentSecuence = 0;
                }
                
                if (maxSecuence < currentSecuence)
                {
                    maxSecuence = currentSecuence;
                    element = numbers[i];
                }
            }


            for (int i = 0; i <= maxSecuence; i++)
            {
                Console.Write(element + " ");
            }
        }
    }
}
