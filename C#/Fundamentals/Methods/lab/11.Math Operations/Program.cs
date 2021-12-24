using System;

namespace _11.Math_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            string operatot = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(num1, operatot, num2));
        }

        static double Calculate(int num1, string operatot, int num2)
        {
            switch (operatot)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    return num1 / num2;
            }
            return 0;
        } 
        
    }
}
