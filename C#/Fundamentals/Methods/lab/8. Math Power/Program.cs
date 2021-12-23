using System;

namespace _8._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int pow = int.Parse(Console.ReadLine());

            double result =PowNumber(number, pow);
            Console.WriteLine(result);

        }

        static double PowNumber(double number, int pow)
        {
            double result = 0d;
            result = Math.Pow(number, pow);


            return result;

        }
    }
}
