using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = data[0];
            int col = data[1];

            string[,] matrix = new string[row, col];

            ReadMatrix(matrix);

            while (true)
            {
                string[] token = Console.ReadLine().Split();
                string command = token[0];

                if (command == "END" )
                {
                    break;
                }

                if (command == "swap" && token.Length == 5)
                {
                    int row1 = int.Parse(token[1]);
                    int col1 = int.Parse(token[2]);
                    int row2 = int.Parse(token[3]);
                    int col2 = int.Parse(token[4]);

                    if (IsValidCordinates(row1, col1, row2, col2, matrix))
                    {
                        Swap(row1, col1, row2, col2, matrix);
                        PrintMatrix(matrix);

                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");

                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void PrintMatrix(string[,] matrix)
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

        private static bool IsValidCordinates(int row1, int col1, int row2, int col2, string[,] matrix)
        {
            return row1 >= 0 && row1 < matrix.GetLength(0) && col1 >= 0 && col1 < matrix.GetLength(1) && row2 >= 0 && row2 < matrix.GetLength(0) && col2 >= 0 && col2 < matrix.GetLength(1);
        }

        private static void Swap(int row1, int col1, int row2, int col2, string[,] matrix)
        {
            string temp = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = temp;
        }

        private static void ReadMatrix(string[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string[] row = Console.ReadLine().Split();

                for (int c= 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = row[c];
                }
            }
        }
    }
}
