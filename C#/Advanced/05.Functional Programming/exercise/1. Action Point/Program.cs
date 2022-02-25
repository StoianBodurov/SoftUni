using System;

namespace _1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" ");

            Action<string> print = name => Console.WriteLine(name);

            foreach(string name in data)
            {
                print(name);
            }
        }
    }
}
