using System;
using System.Text;

namespace _5._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();

            StringBuilder digits = new StringBuilder();
            StringBuilder chars = new StringBuilder();
            StringBuilder other = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                char ch = data[i];
                if (Char.IsLetter(ch))
                {
                    chars.Append(ch);
                }
                else if (Char.IsDigit(ch))
                {
                    digits.Append(ch);
                }
                else
                {
                    other.Append(ch);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(chars);
            Console.WriteLine(other);
        }
    }
}
