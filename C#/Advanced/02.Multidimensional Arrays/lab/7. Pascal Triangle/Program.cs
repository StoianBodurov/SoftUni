using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());

            int[][] pascalTriangle = new int[row][];
            int[] firstRow = new int[1];
            firstRow[0] = 1;
            pascalTriangle[0] = firstRow;

            int[] secondRow = new int[2];
            secondRow[0] = 1;
            secondRow[1] = 1;
            pascalTriangle[1] = secondRow;

            for (int r = 2; r < row; r++)
            {
                int[] newRow = new int[r + 1];
                for (int i = 0; i < newRow.Length; i++)
                {
                    if (i == 0)
                    {
                        newRow[i] = 1;
                    }
                    else if (i == newRow.Length - 1)
                    {
                        newRow[i] = 1;
                    }
                    else
                    {
                        newRow[i] = pascalTriangle[r - 1][i] + pascalTriangle[r - 1][i - 1];
                    }
                }
                pascalTriangle[r] = newRow;
            }

            PrintMatrix(pascalTriangle);
        }
        private static void PrintMatrix(int[][] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    Console.Write(matrix[r][ c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
