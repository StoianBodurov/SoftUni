using System;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string text = Console.ReadLine();

                if (text == "end")
                {
                    break;
                }
                string result = "";

                for (int i = text.Length - 1; i >= 0; i--)
                {
                    result += text[i];
                }
                Console.WriteLine($"{text} = {result}");
            }
            
        }
    }
}
