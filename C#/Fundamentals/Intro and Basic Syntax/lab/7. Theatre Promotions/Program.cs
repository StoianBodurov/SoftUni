using System;

namespace _7._Theatre_Promotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayType = Console.ReadLine();
            int personAge = int.Parse(Console.ReadLine());
            int price = 0;
            bool isCorectAge = true;
            if (dayType == "Weekday")
            {
                if ( 0 <= personAge && personAge <= 18)
                {
                    price = 12;
                } else if (18 < personAge && personAge <= 64)
                {
                    price = 18;
                } else if (64 < personAge && personAge <= 122) {
                    price = 12;
                } else
                {
                    isCorectAge = false;
                }
            } else if (dayType == "Weekend")
            {
                if (0 <= personAge && personAge <= 18)
                {
                    price = 15;
                }
                else if (18 < personAge && personAge <= 64)
                {
                    price = 20;
                }
                else if (64 < personAge && personAge <= 122)
                {
                    price = 15;
                }
                else
                {
                    isCorectAge = false;
                }
            } else
            {
                if (0 <= personAge && personAge <= 18)
                {
                    price = 5;
                }
                else if (18 < personAge && personAge <= 64)
                {
                    price = 12;
                }
                else if (64 < personAge && personAge <= 122)
                {
                    price = 10;
                }
                else
                {
                    isCorectAge = false;
                }
            }

            if (isCorectAge)
            {
                Console.WriteLine(price + "$");
            } else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
