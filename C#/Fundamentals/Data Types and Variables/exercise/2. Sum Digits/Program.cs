using System;

namespace _2._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            while (number > 0)
            {
                int n = number % 10;
                sum += n;
                number /= 10;
            }

            Console.WriteLine(sum);

        }
    }
}
