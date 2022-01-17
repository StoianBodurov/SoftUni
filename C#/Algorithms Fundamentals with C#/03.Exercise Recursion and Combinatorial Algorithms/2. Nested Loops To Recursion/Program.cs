using System;

namespace _2._Nested_Loops_To_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] result = new int[n];


            genResult(0, result);
        }

        private static void genResult(int index, int[] result)
        {
            if (index >= result.Length)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = 1; i <= result.Length; i++)
            {
                result[index] = i;
                genResult(index + 1, result);
            }
        }
    }
}
