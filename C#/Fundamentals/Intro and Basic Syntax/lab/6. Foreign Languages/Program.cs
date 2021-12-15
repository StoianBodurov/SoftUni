using System;

namespace _6._Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string counrtry = Console.ReadLine();

            if (counrtry == "USA" || counrtry == "England")
            {
                Console.WriteLine("English");
            } else if (counrtry == "Spain" || counrtry == "Argentina" || counrtry == "Mexico")
            {
                Console.WriteLine("Spanish");
            } else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
