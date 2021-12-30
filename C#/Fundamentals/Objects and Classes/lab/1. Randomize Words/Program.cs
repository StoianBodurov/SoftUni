using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();

            Random rnd = new Random();
            int minValue = 0;
            int maxValue = words.Count;

            while( words.Count > 0)
            {
                
                string randomWord =  words[rnd.Next(minValue, maxValue)];
                Console.WriteLine(randomWord);
                words.Remove(randomWord);
                maxValue--;
            }
            

        }
    }
}
