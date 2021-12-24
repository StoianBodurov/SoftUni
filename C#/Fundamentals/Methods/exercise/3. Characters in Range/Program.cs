using System;

namespace _3._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());
            PrintCharacters(char1, char2);
            
        }

        static void PrintCharacters(char char1, char char2)
        {
            
            int start = (int)char1;
            int stop = (int)char2;
            if (char1 > char2)
            {
                start = (int)char2;
                stop = (int)char1;
            }

            for (int i = start + 1; i < stop; i++)
            {
                Console.Write((char)i + " ");
            }
            Console.WriteLine();
        }
    }
}
