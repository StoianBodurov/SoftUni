using System;
using System.Linq;

namespace _2.__2X2_Squares_in_Matrix
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
            int count = 0;

            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c <matrix.GetLength(1) - 1; c++)
                {
                    if (matrix[r, c] == matrix[r, c + 1] && matrix[r, c] == matrix[r + 1, c] && matrix[r, c] == matrix[r + 1, c + 1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }

        private static void ReadMatrix(string[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string[] currentRow = Console.ReadLine().Split();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = currentRow[c];
                }
            }
        }
    }


}
