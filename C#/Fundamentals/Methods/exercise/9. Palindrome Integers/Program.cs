using System;

namespace _9._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                if (CheckIsPalindrom(input))
                {
                    Console.WriteLine("true") ;
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static bool CheckIsPalindrom(string input)
        {

            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
