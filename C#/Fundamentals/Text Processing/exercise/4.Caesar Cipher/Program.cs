using System;
using System.Text;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int asciiNum = text[i];
                char newchar = Convert.ToChar(asciiNum + 3);
                result.Append(newchar);
            }

            Console.WriteLine(result);
        }
    }
}
