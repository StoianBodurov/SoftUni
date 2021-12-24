using System;

namespace _2._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Console.WriteLine(GetVowelsCount(text));
        }

        static int GetVowelsCount(string text)
        {
            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if ((text.ToLower()[i] == 'a' || text.ToLower()[i] == 'e' || text.ToLower()[i] == 'i' || text.ToLower()[i] == 'o' || text.ToLower()[i] == 'u'))
                {
                    count += 1;
                }
                

            }

            return count;
        }
    }
}
