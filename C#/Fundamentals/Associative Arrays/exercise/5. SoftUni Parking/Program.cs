using System;
using System.Collections.Generic;

namespace _5._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> parking = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] token = Console.ReadLine().Split();

                string command = token[0];
                string userName = token[1];

                if (command == "register")
                {
                    if (parking.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {parking[userName]}");
                    }
                    else
                    {
                        string plateNumber = token[2];
                        parking[userName] = plateNumber;
                        Console.WriteLine($"{userName} registered {plateNumber} successfully");
                    }
                }
                else
                {
                    if (!parking.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                    else
                    {
                        parking.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }

                }
            }

            foreach (var item in parking)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
