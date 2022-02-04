using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];

            int[,] matrix = new int[row, col];

            for (int r = 0; r < row; r++)
            {
                int[] matrixRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = matrixRow[c];
                }
            }

            int matrixSum = 0;

            foreach (int el in matrix)
            {
                matrixSum += el;
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(matrixSum);
        }
    }
}
