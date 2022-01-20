using System;

namespace _6._Combinations_with_Repetition
{
    class Program
    {
        private static string[] elements;
        private static string[] slots;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            slots = new string[n];

            GetCombinations(0, 0);
        }

        private static void GetCombinations(int index, int start)
        {
            if (index >= slots.Length)
            {
                Console.WriteLine(string.Join(" ", slots));
            }
            else
            {
                for (int i = start; i < elements.Length; i++)
                {
                    slots[index] = elements[i];
                    GetCombinations(index + 1, i);
                }
            }
        }
    }
}
