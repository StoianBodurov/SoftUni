using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../Input.txt"))
            {
                var line = reader.ReadLine();
                int counter = 1;

                while (line != null)
                {
                    Console.WriteLine($"{counter}. {line}");
                    counter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
