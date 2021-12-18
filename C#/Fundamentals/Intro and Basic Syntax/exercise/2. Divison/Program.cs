using System;

namespace _2._Divison
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == (n / 10) * 10)
            {
                Console.WriteLine("The number is divisible by 10");
            }
            else if (n == (n / 7) * 7)
            {
                Console.WriteLine("The number is divisible by 7");
            }
            else if (n == (n / 6) * 6)
            {
                Console.WriteLine("The number is divisible by 6");
            }
            else if (n == (n / 3) * 3)
            {
                Console.WriteLine("The number is divisible by 3");
            }
            else if (n == (n / 2) * 2)
            {
                Console.WriteLine("The number is divisible by 2");
            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
