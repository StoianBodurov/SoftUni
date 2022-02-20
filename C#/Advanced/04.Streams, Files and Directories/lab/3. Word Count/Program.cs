using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            using(var reader = new StreamReader("../../../words.txt"))
            {
                var line = reader.ReadLine().Split(new char[] { '.', ',', ' ', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);

                foreach(var word in line)
                {
                    words.Add(word.ToLower(), 0);
                }
            }

            using(var reader = new StreamReader("../../../text.txt"))
            {
                var line = reader.ReadLine();

                while(line != null)
                {
                    var data = line.Split(new char[] { '.', ',', ' ', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in data)
                    {
                        if (words.ContainsKey(word.ToLower()))
                        {
                            words[word.ToLower()] += 1;
                        }
                    }
                    line = reader.ReadLine();
                }
                
            }

            var sortedWords = words.OrderByDescending(x => x.Value);

            foreach(var word in sortedWords)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
