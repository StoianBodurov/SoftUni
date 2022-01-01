using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            while (true)
            {
                string[] data = Console.ReadLine().Split();

                if (data[0] == "End")
                {
                    break;
                }

                string type = data[0];
                type = type[0].ToString().ToUpper() + type.Substring(1);
                string model = data[1];
                string color = data[2];
                int horsePower = int.Parse(data[3]);

                vehicles.Add(new Vehicle(type, model, color, horsePower));

            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Close the Catalogue")
                {
                    break;
                }

                Vehicle serched = vehicles.Find(v => command == v.Model);

                if (serched != null)
                {
                    Console.WriteLine($"Type: {serched.Type}");
                    Console.WriteLine($"Model: {serched.Model}");
                    Console.WriteLine($"Color: {serched.Color}");
                    Console.WriteLine($"Horsepower: {serched.HorsePower}");

                }
            }

            List<Vehicle> cars = vehicles.FindAll(v => v.Type == "Car");
            List<Vehicle> trucks = vehicles.FindAll(v => v.Type == "Truck");

            Console.WriteLine($"Cars have average horsepower of: {AverageHorspower(cars):f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {AverageHorspower(trucks)}.");
        }

        static double AverageHorspower(List<Vehicle> vehicles)
        {
            if (vehicles.Count == 0)
            {
                return 0;
            }
            double sumHorspower = 0;

            foreach (var v in vehicles)
            {
                sumHorspower += v.HorsePower;
            }

            return sumHorspower / vehicles.Count();
            
        }
    }
}
