using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            float[][] matrix = new float[row][];

            ReadMatrix(row, matrix);
            MuttateMatrix(matrix);

            while (true)
            {
                string[] token = Console.ReadLine().Split();
                string command = token[0];
                if (command == "End")
                {
                    break;
                }

                int r = int.Parse(token[1]);
                int c = int.Parse(token[2]);
                int value = int.Parse(token[3]);
                if (IsValidCordinates(r, c, matrix))
                {
                    if (command == "Add")
                    {
                        matrix[r][c] += value;
                    }
                    else if (command == "Subtract")
                    {
                        matrix[r][c] -= value;
                    }
                }

            }

            PrintMatrix(matrix);
        }

        private static void MuttateMatrix(float[][] matrix)
        {
            for (int r = 0; r < matrix.Length -1; r++)
            {
                if (matrix[r].Length == matrix[r + 1].Length)
                {
                    for (int c = 0; c < matrix[r].Length; c++)
                    {
                        matrix[r][c] *= 2;
                        matrix[r + 1][c] *= 2;
                    }
                }
                else
                {
                    for (int c = 0; c < matrix[r].Length; c++)
                    {
                        matrix[r][c] /= 2;
                    }
                    for (int c = 0; c < matrix[r + 1].Length; c++)
                    {
                        matrix[r + 1][c] /= 2;
                    }

                }
            }
        }

        private static bool IsValidCordinates(int r, int c, float[][] matrix)
        {
            return r >= 0 && r < matrix.Length && c >= 0 && c < matrix[r].Length;
        }

        private static void ReadMatrix(int row, float[][] matrix)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                float[] currentRow = Console.ReadLine().Split().Select(float.Parse).ToArray();

                matrix[r] = currentRow;
            }
        }

        private static void PrintMatrix(float[][] matrix)
        {
            foreach(var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
