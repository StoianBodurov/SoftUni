using System;

namespace _3._Variations_without_Repetitions
{
    class Program
    {
        private static string[] elements;
        private static string[] variation;
        private static bool[] used;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            int slotsNumber = int.Parse(Console.ReadLine());
            variation = new string[slotsNumber];
            used = new bool[elements.Length];


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
                    if (!used[i])
                    {
                        used[i] = true;
                        variation[index] = elements[i];
                        GetVariations(index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
