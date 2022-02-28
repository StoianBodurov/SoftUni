using System;
using System.Linq;

namespace _9._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Predicate<int> checker = n => IsDivide(n, numbers);

            for(int i = 1; i <= number; i++)
            {
                if (checker(i))
                {
                    Console.Write(i + " ");
                }
            }

        }

        private static bool IsDivide(int number, int[] numbers)
        {
            bool divide = true;
            foreach(var n in numbers)
            {
                if(number % n != 0)
                {
                    divide = false;
                }
            }

            return divide;
        }

    }
}
