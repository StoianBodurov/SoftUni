﻿using System;
using System.Linq;

namespace _4._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] sorted = numbers.OrderByDescending(n => n).ToArray();

            if (sorted.Length < 3)
            {
                Console.WriteLine(String.Join(" ", sorted));
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(sorted[i] + " ");
                }
            }
        }
    }
}
