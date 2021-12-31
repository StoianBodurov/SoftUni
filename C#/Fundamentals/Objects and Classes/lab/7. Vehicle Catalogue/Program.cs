using System;
using System.Collections.Generic;

namespace _7._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog {
                Cars = new List<Car>(),
                Trucks = new List<Truck>(),

            };
            while (true)
            {
                string[] data = Console.ReadLine().Split("/");
                if (data[0] == "end")
                {
                    break;
                }

                string vehicle = data[0];
                string brand = data[1];
                string model = data[2];

                if (vehicle == "Car")
                {
                    int horsePowerv = int.Parse(data[3]);

                    Car car = new()
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = horsePowerv,
                    };

                    catalog.Cars.Add(car);
                }
                else
                {
                    int weight = int.Parse(data[3]);

                    Truck truck = new()
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight,
                    };

                    catalog.Trucks.Add(truck);
                }
            }

            catalog.Cars.Sort((x, y) => x.Brand.CompareTo(y.Brand));
            catalog.Trucks.Sort((x, y) => x.Brand.CompareTo(y.Brand));

            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in catalog.Cars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in catalog.Trucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }

            }

        }
    }
   
}
