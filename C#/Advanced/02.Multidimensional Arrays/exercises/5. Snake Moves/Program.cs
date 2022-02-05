using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = data[0];
            int col = data[1];

            string[,] matrix = new string[row, col];
            string inputString = Console.ReadLine();

            int cuurentIndex = 0;

            for (int r =0; r < matrix.GetLength(0); r++)
            {
                

                if (r % 2 == 0)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        if (cuurentIndex == inputString.Length)
                        {
                            cuurentIndex = 0;
                        }
                        matrix[r, c] = inputString[cuurentIndex].ToString();
                        cuurentIndex++;
                    }
                }
                else
                {
                    for (int c = matrix.GetLength(1) - 1; c >= 0; c--)
                    {
                        if (cuurentIndex == inputString.Length)
                        {
                            cuurentIndex = 0;
                        }
                        matrix[r, c] = inputString[cuurentIndex].ToString();
                        cuurentIndex++;
                    }
                }
            }

            PrintMatrix(matrix);

        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
