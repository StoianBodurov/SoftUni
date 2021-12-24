using System;

namespace _1._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            Console.WriteLine(GetSmallestNumber(number1, number2, number3));

        }

        static int GetSmallestNumber(int number1, int number2, int number3)
        {
            if (number1 < number2 && number1 < number3)
            {
                return number1;
            }
            else if (number2 < number1 && number2 < number3)
            {
                return number2;
            }
            return number3;
        }
    }
}
