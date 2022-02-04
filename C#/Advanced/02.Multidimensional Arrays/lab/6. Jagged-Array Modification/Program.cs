using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            ReadMatrix(n, n, matrix);

            while (true)
            {
                string[] token = Console.ReadLine().Split();
                string command = token[0];
                if (command == "END")
                {
                    break;
                }

                int row = int.Parse(token[1]);
                int col = int.Parse(token[2]);
                int value = int.Parse(token[3]);
                if (InMatrix(row, col, matrix))
                {
                    if (command == "Add")
                    {
                        matrix[row, col] += value;
                    }
                    else
                    {
                        matrix[row, col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

            PrintMatrix(matrix);

        }

        private static bool InMatrix(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
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

        private static void PrintMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
