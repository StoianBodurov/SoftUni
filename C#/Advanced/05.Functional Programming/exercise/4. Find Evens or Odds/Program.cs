using System;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            int start = input[0];
            int end = input[1];

            Predicate<int> EvenNumber = n => n % 2 == 0;
            Predicate<int> OddNumber = n => n % 2 != 0;

            for(int i = start; i <= end; i++)
            {
                if (command == "even" && EvenNumber(i))
                {
                    Console.Write(i);
                }
                else if (command == "odd" && !EvenNumber(i))
                {
                    Console.Write(i);
                }
            }
            Console.WriteLine();

            

            

        }
    }
}
