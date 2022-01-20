using System;

namespace _4._Variations_with_Repetition
{
    class Program
    {
        private static string[] elements;
        private static string[] variation;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            int slotsNumber = int.Parse(Console.ReadLine());
            variation = new string[slotsNumber];

            GetVariations(0);
        }

        private static void GetVariations(int index)
        {
            if (index >= variation.Length)
            {
                Console.WriteLine(string.Join(" ", variation));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    variation[index] = elements[i];
                    GetVariations(index + 1);
                }
            }
        }
    }
}
