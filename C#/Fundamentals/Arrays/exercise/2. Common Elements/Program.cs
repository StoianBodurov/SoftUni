using System;

namespace _2._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split();
            string[] array2 = Console.ReadLine().Split();

            foreach (var el in array2)
            {
                foreach (var e in array1)
                {
                    if (el == e)
                    {
                        Console.Write(e + ' ');
                    }
                }
            }
        }
    }
}
