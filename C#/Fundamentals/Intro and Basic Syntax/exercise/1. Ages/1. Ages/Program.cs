using System;

namespace _1._Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());

            if (0 <= age && age <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (2 < age && age <= 13)
            {
                Console.WriteLine("child");
            }
            else if (13 < age && age <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (19 < age && age <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (65 < age)
            {
                Console.WriteLine("elder");
            }
        }
    }
}
