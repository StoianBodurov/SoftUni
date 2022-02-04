using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = data[0];
            int col = data[1];

            int[,] matrix = new int[row, col];

            ReadMatrix(matrix);
            int maxSum = 0;
            int[,] resultMatrix = new int[3, 3];

            for (int r = 0; r < matrix.GetLength(0) - 2; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 2; c++)
                {
                    int[,] tempMatrix = new int[3, 3];
                    int currentSum = 0;

                    for (int i = r; i < r + 3; i++)
                    {
                        for (int j = c; j < c + 3; j++)
                        {
                            currentSum += matrix[i, j];
                            tempMatrix[i - r, j - c] = matrix[i, j];
                        }
                        
                    }
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        resultMatrix = tempMatrix;

                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            PrintMatrix(resultMatrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
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
