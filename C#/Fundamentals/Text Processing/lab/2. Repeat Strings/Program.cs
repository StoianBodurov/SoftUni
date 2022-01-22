using System;
using System.Text;

namespace _2._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();

            StringBuilder result = new StringBuilder();

            foreach (var word in data)
            {
                for (int i = 0; i < word.Length; i++)
                    result.Append(word);
            }

            Console.WriteLine(result);
        }
    }
}
