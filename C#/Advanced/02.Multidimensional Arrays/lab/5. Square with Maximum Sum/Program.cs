using System;
using System.Linq;

namespace _5._Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int row = data[0];
            int col = data[1];
            int[,] matrix = new int[row, col];
            int[,] squareMatrix = new int[2, 2];

            ReadMatrix(row, col, matrix);
            int squareMatrixSum = 0;

            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    int currentSum = matrix[r, c] + matrix[r, c + 1] + matrix[r + 1, c] + matrix[r + 1, c + 1];
                    if (currentSum > squareMatrixSum)
                    {
                        squareMatrixSum = currentSum;
                        squareMatrix[0, 0] = matrix[r, c];
                        squareMatrix[0, 1] = matrix[r, c + 1];
                        squareMatrix[1, 0] = matrix[r + 1, c];
                        squareMatrix[1, 1] = matrix[r + 1, c + 1];
                    }

                }
            }

            PrintMatrix(squareMatrix);
            Console.WriteLine(squareMatrixSum);


        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int r = 0;r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void ReadMatrix(int row, int col, int[,] matrix)
        {
            for (int r = 0; r < row; r++)
            {
                int[] matrixRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = matrixRow[c];
                }
            }
        }
    }
}
