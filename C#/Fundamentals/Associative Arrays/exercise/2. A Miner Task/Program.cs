using System;
using System.Collections.Generic;

namespace _2._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string resource = string.Empty;
            Dictionary<string, int> minerResources= new Dictionary<string, int>();

            while (true)
            {
                string data = Console.ReadLine();

                counter++;
                
                if (data == "stop")
                {
                    break;
                }

                if (counter % 2 == 1)
                {
                    resource = data;
                }
                else
                {
                    int quantity = int.Parse(data);

                    if (!minerResources.ContainsKey(resource))
                    {
                        minerResources.Add(resource, 0);
                    }

                    minerResources[resource] += quantity;
                    resource = string.Empty;
                }
            }

            foreach(var item in minerResources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
