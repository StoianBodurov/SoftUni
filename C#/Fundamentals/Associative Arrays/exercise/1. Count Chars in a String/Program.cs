using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> charsCount = new Dictionary<char, int>();

            foreach (var c in text)
            {
                if (c == ' ')
                {
                    continue;
                }

                if (!charsCount.ContainsKey(c))
                {
                    charsCount.Add(c, 0);
                }
                charsCount[c]++;
            }

            foreach (var item in charsCount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
