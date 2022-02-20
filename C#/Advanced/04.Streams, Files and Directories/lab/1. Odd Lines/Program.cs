using System;
using System.IO;

namespace _1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../Input.txt"))
            {
                int counter = 0;
                var line = reader.ReadLine();
                while(line != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    counter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
