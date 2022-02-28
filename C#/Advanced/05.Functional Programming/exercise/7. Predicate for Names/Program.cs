using System;
using System.Linq;

namespace _7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int wordLength = int.Parse(Console.ReadLine());
            Predicate<string> cheker = n => n.Length <= wordLength;

            string[] names = Console.ReadLine().Split(" ").Where(w => cheker(w)).ToArray();

            Console.WriteLine(string.Join("\n", names));
        }
    }
}
