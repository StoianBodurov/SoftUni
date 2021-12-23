using System;

namespace _4._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintingTriangle(n);
        }

        static void PrintingTriangle(int n)
        {
            for (int row = 1; row <= n; row++)
            {
                PrintRow(row);
            }

            for (int row = n - 1; row > 0; row--)
            {
                PrintRow(row);
            }
        }

        static void PrintRow(int row)
        {
            for (int j = 1; j <= row; j++)
            {
                Console.Write($"{j} ");
            }
            Console.WriteLine();
        }
    }
}
