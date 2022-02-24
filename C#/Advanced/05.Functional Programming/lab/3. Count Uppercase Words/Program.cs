using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> GetUppercaseWords = x => char.IsUpper(x[0]);
            string[] words = Console.ReadLine()
                .Split( " ", StringSplitOptions.RemoveEmptyEntries)
                .Where(GetUppercaseWords).ToArray();

            foreach(string word in words)
            {
                Console.WriteLine(word);
            }
        }

       
    }
}
