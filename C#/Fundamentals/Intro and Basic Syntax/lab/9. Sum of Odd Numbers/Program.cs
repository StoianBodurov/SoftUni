using System;

namespace _9._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int curentNumber = 1;
            int sum = 0;
            while (n >0)
            {
                Console.WriteLine(curentNumber);
                sum += curentNumber;
                curentNumber += 2;
                n--;
            }
            Console.WriteLine("Sum: " + sum);
        }
    }
}
