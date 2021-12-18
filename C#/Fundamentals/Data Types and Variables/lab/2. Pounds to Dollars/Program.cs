using System;

namespace _2._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pounds = decimal.Parse(Console.ReadLine());
            decimal poundToDolar = 1.31m;
            decimal dolars = pounds * poundToDolar;
            Console.WriteLine($"{dolars:f3}");

        }
    }
}
