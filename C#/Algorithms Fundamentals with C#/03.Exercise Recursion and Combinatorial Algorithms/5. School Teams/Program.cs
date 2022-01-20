using System;
using System.Collections.Generic;

namespace _5._School_Teams
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] girls = Console.ReadLine().Split(", ");
            string[] boys = Console.ReadLine().Split(", ");

            string[] boysCombination = new string[2];
            string[] girlssCombination = new string[3];

            List<string> boysResult = new List<string>();
            List<string> girlsResult = new List<string>();
        
            GetCombination(0, 0, boys, boysCombination, boysResult);
            GetCombination(0, 0, girls, girlssCombination, girlsResult);

            foreach (var g in girlsResult)
            {
                foreach (var b in boysResult)
                {
                    Console.WriteLine($"{g}, {b}");
                }
            }
        }

        private static void GetCombination(int index, int start, string[] data, string[] combination, List<string> result)
        {
            if (index >= combination.Length)
            {
                result.Add(string.Join(", ",combination));
            }
            else
            {
                for (int i = start; i < data.Length; i++)
                {
                    combination[index] = data[i];
                    GetCombination(index + 1, i + 1, data, combination, result);
                }
            }
        }
    }
}
