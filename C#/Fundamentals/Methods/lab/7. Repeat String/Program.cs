﻿using System;

namespace _7._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string result = RepeatString(text, count);

            Console.WriteLine(result);
        }

        static string RepeatString(string text, int count)
        {
            string result = "";

            for (int i = 0; i < count; i++)
            {
                result += text;
            }

            return result;
        }
    }
}
