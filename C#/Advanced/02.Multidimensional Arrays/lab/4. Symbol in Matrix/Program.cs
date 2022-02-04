using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];
            ReadMatrix(n, n, matrix);

            string searchedSymbol = Console.ReadLine();
            bool isOccurrence = false;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == searchedSymbol)
                    {
                        isOccurrence = true;
                        Console.WriteLine($"({r}, {c})");
                        break;
                    }
                }

                if (isOccurrence)
                {
                    break;
                }
            }
            if (!isOccurrence)
            {
                Console.WriteLine($"{searchedSymbol} does not occur in the matrix");
            }

        }

        private static void ReadMatrix(int row, int col, string[,] matrix)
        {
            for (int r = 0; r < row; r++)
            {
                string matrixRow = Console.ReadLine();
                for (int c = 0; c < col; c++)
                {
                    matrix[r, c] = matrixRow[c].ToString();
                }
            }
        }
    }
}
