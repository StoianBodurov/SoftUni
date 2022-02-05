using System;
using System.Collections.Generic;

namespace Problem_3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                foreach(var el in data)
                {
                    elements.Add(el);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
