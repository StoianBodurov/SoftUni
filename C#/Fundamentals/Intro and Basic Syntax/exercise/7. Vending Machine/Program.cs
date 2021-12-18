using System;

namespace _7._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double money = 0;
            

            while (command != "Start")
            {

                double coins = double.Parse(command);

                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    money += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                double price = 0;
                string product = command;

                if (product == "Nuts")
                {
                    price += 2;
                }
                else if (product == "Water")
                {
                    price += 0.7;
                }
                else if (product == "Crisps")
                {
                    price += 1.5;
                }
                else if (product == "Soda")
                {
                    price += 0.8;
                }
                else if (product == "Coke")
                {
                    price += 1;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                if (price != 0)
                {
                    if (price <= money)
                    {
                        money -= price;
                        Console.WriteLine($"Purchased {product.ToLower()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Change: {money:f2}");
        }
    }
}
