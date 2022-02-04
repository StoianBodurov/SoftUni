using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            ReadMatrix(matrix);
            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for ( int r = 0; r < matrix.GetLength(0); r++)
            {
                primaryDiagonalSum += matrix[r, r];
                secondaryDiagonalSum += matrix[r, matrix.GetLength(1) - 1 - r];
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }

        private static void ReadMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = currentRow[c];
                }
            }
        }
    }
}
