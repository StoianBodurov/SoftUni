using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < n; i++)
            {
                List<string> commands = Console.ReadLine().Split().ToList();

                string name = commands[0];
                string command = commands[1];

                if (commands.Count == 3)
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{ name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
                else
                {
                    if (guests.Contains(name))
                    {
                        guests.Remove(name);    
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }
            foreach(var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
