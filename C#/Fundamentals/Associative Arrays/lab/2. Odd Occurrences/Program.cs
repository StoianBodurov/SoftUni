using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().Select(w => w.ToLower()).ToArray();

            Dictionary<string, int> wordCounter = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordCounter.ContainsKey(word))
                {
                    wordCounter.Add(word, 0);
                }
                wordCounter[word]++;
            }

            foreach (var item in wordCounter)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");
                }
            }

        }
    }
}
