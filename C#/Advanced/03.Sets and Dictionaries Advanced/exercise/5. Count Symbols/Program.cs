using System;
using System.Collections.Generic;

namespace _5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> characters = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (!characters.ContainsKey(ch))
                {
                    characters.Add(ch, 0);
                }

                characters[ch] += 1;
            }

            foreach (var keyValue in characters)
            {
                Console.WriteLine($"{keyValue.Key}: {keyValue.Value} time/s");
            }
        }
    }
}
