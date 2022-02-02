using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            Stack<char> result = new Stack<char>();

            for (int i = 0; i < data.Length; i++)
            {
                result.Push(data[i]);
            }

            while (result.Count > 0)
            {
                Console.Write(result.Pop());
            }
            Console.WriteLine();

        }
    }
}
