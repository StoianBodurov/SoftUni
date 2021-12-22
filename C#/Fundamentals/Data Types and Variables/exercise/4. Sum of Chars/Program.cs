using System;

namespace _4._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int charSum = 0;

            for (int i = 1; i <= n; i++)
            {
                string letter = Console.ReadLine();
                charSum += (int)letter[0];
            }
            Console.WriteLine($"The sum equals: {charSum}");
        }
    }
}
