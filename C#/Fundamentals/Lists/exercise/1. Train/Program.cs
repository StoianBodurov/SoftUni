using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int wagonCapacity = int.Parse(Console.ReadLine());

            while (true)
            {
                List<string> commands = Console.ReadLine().Split().ToList();
                
                if (commands[0] == "end")
                {
                    break;
                }

                if (commands[0] == "Add")
                {
                    int passengers = int.Parse(commands[1]);
                    wagons.Add(passengers);
                }
                else
                {
                    int passengers = int.Parse(commands[0]);
                    AddPassengers(wagons, passengers, wagonCapacity);
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        static void AddPassengers(List<int> wagons, int passengers, int wagonCapacity)
        {
            for (int i = 0; i < wagons.Count(); i++)
            {
                if (wagonCapacity - wagons[i] >= passengers)
                {
                    wagons[i] += passengers;
                    break;
                }
            }
        }
    }
}
