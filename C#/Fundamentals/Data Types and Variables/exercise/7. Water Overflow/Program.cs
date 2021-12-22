using System;

namespace _7._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int tankCapacity = 255;
            int tankCurrentQuantiti = 0;

            for (int i = 0; i < n; i++)
            {
                int waterQuantiti = int.Parse(Console.ReadLine());
                if ((tankCurrentQuantiti + waterQuantiti) > tankCapacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    tankCurrentQuantiti += waterQuantiti;
                }
            }
            Console.WriteLine(tankCurrentQuantiti);
        }
    }
}
