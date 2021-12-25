using System;

namespace _7._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double result = GetFactorial(num1) / GetFactorial(num2);

            Console.WriteLine($"{result:f2}");
        }

        static int GetFactorial(int num)
        {
            //if (num == 1)
            //{
            //    return 1;
            //}

            //return num * GetFactorial(num - 1);

            int result = 1;

            for (int i = 1; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
