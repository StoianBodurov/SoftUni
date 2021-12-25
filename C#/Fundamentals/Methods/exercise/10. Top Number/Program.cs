using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (PrintMasterNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool PrintMasterNumber(int number)
        {
            bool isMasterNumber = false;
            bool isOdd = false;
            int digitSum = 0;
            while (number > 0)
            {
                int n = number % 10;
                if (n % 2 != 0)
                {
                    isOdd = true;
                }
                digitSum += n;
                number /= 10;
            }
        
            if  (digitSum % 8 == 0 && isOdd)
            {
                isMasterNumber = true;
            }
            

            return isMasterNumber;
        }
    }
}
