using System;
using System.Collections;
using System.Collections.Generic;

namespace _2._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            Stack<int> indexses = new Stack<int>();


            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '(')
                {
                    indexses.Push(i);
                }
                else if (data[i] == ')')
                {
                    int index = indexses.Pop();
                    Console.WriteLine(data.Substring(index, i - index + 1)) ;

                }
            }
        }
    }
}
