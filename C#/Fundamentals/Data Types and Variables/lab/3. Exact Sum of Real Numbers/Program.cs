using System;

namespace _3._Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            decimal sum = 0;

            for (int i = 0; i < number; i++)
            {
                decimal n = decimal.Parse(Console.ReadLine());
                sum += n;

            }
            Console.WriteLine(sum);
        }
    }
}
