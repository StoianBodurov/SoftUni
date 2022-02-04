using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            ReadMatrix(n, n, matrix);
            int sumPrimaryDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sumPrimaryDiagonal += matrix[i, i];
            }
            Console.WriteLine(sumPrimaryDiagonal);
        }

        private static void ReadMatrix(int row, int col, int[,] matrix)
        {
            for (int r = 0; r < row; r++)
            {
                int[] matrixRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = matrixRow[c];
                }
            }
        }
    }
}
