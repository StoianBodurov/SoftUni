using System;

namespace _6._Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int factorialSum = 0;

            for (var i = 0; i < number.Length; i++)
            {
                int n = int.Parse(number[i].ToString());
                Console.WriteLine(n);
                int factorial = 1;
                for (var j = 1; j <= n; j++)
                {
                    factorial *= j;
                    //Console.WriteLine(j);
                }
                factorialSum += factorial;
                //Console.WriteLine(factorial);
                
            }

            if (int.Parse(number) == factorialSum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
