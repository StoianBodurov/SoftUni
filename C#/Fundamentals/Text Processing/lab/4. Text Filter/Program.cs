using System;

namespace _4._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] banWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (string word in banWords)
            {
                text = text.Replace(word, new String('*', word.Length));
            }

            Console.WriteLine(text);
        }
    }
}
