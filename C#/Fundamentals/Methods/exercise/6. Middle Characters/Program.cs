using System;

namespace _5._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Console.WriteLine(GetMiddleCharacter(text));
        }

        static string GetMiddleCharacter(string text)
        {
            string result = "";
            int MiddleIndex = text.Length / 2;
            if (text.Length % 2 == 0)
            {
                result = text[MiddleIndex - 1].ToString() + text[MiddleIndex].ToString();
            }
            else
            {
                
                result = text[MiddleIndex].ToString();
            }
            return result;
        }
    }
}
