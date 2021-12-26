using System;
using System.Collections.Generic;

namespace _7._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrays = Console.ReadLine().Split("|");
            List<string> result = new List<string>();

            for (int i = arrays.Length - 1; i >= 0; i--)
            {
                string[] array = arrays[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach(var el in array)
                {
                    result.Add(el);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
