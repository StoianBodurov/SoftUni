using System;

namespace Problem_1___Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalPrice = 0;
            string command = Console.ReadLine();
            while (true)
            {

                if (command == "special" || command == "regular")
                {
                    break;
                }

                double price = double.Parse(command);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    
                }
                else
                {
                    totalPrice += price;

                }
                command = Console.ReadLine();
            }

            if (totalPrice == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                double taxes = totalPrice * 0.2;
                double priceWitTaxes = totalPrice * 1.2;

                if (command == "special")
                {
                    priceWitTaxes *= 0.9;
                }
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalPrice:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {priceWitTaxes:f2}$");
            }
        }
    }
}
