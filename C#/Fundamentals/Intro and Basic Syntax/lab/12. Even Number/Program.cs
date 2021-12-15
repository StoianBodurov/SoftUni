using System;

namespace _12._Even_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = Math.Abs(int.Parse(Console.ReadLine()));
                if (n == (n / 2) * 2)
                {
                    Console.WriteLine($"The number is: {n}");
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                }
            }
        }
    }
}
