using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];

            int[,] matrix = new int[row, col];


            ReadMatrix(row, col, matrix);
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(matrix.GetLength(0));

            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                int colSum = 0;

                for (int r = 0; r < matrix.GetLength(0); r++)
                {
                    colSum += matrix[r, c];
                }
                Console.WriteLine(colSum);
            }
            
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
