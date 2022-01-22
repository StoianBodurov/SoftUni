using System;

namespace _2.__Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();
            string firstString = data[0];
            string secondString = data[1];
            int result = 0;

            for (int i = 0; i < Math.Max(firstString.Length, secondString.Length); i++)
            {
                int firstCode = 1;
                int secondCode = 1;

                if (firstString.Length > i)
                {
                    firstCode = firstString[i];
                }
                if (secondString.Length > i)
                {
                    secondCode = secondString[i];
                }

                result += firstCode * secondCode; 
            }

            Console.WriteLine(result);
        }
    }
}
