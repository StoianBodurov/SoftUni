using System;
using System.Collections.Generic;
using System.Text;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int nuberOfOperations = int.Parse(Console.ReadLine());
            Stack<string> memeory = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < nuberOfOperations; i++)
            {
                string[] token = Console.ReadLine().Split();
                int command = int.Parse(token[0]);

                switch (command)
                {
                    case 1:
                        string newText = token[1];
                        memeory.Push(text);
                        text += newText;
                        break;
                    case 2:
                        int countToErase = int.Parse(token[1]);
                        memeory.Push(text);
                        text = text.Substring(0, text.Length - countToErase);
                        break;
                    case 3:
                        int index = int.Parse(token[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case 4:
                        text = memeory.Pop();
                        break;
                }

            }
        }
    }
}
