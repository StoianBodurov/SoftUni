using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Legendary_Farming
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, int> elements = new Dictionary<string, int>();
            Dictionary<string, int> junkElements = new Dictionary<string, int>();
            Dictionary<string, string> legendariElements = new Dictionary<string, string>();

            elements["shards"] = 0;
            elements["fragments"] = 0;
            elements["motes"] = 0;

            legendariElements["shards"] = "Shadowmourne";
            legendariElements["fragments"] = "Valanyr";
            legendariElements["motes"] = "Dragonwrath";

            string obtainedElement = string.Empty;

            while (true)
            {
                string[] data = Console.ReadLine().Split();
                bool isObtained = false;

                for (int i = 0; i < data.Length - 1; i += 2)
                {
                    int quantity = int.Parse(data[i]);
                    string element = data[i + 1].ToLower();

                    if (elements.ContainsKey(element))
                    {
                        elements[element] += quantity;
                        if (elements[element] >= 250)
                        {
                            elements[element] -= 250;
                            obtainedElement = element;
                            isObtained = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkElements.ContainsKey(element))
                        {
                            junkElements[element] = 0;
                        }
                        junkElements[element] += quantity;
                    }

                }
                    if (isObtained)
                    {
                        break;
                    }

            }

            Dictionary<string, int> sortedElements = elements.OrderByDescending(e => e.Value).ThenBy(e => e.Key).ToDictionary(e => e.Key, e => e.Value);
            Dictionary<string, int> sortedjunkElements = junkElements.OrderBy(e => e.Key).ToDictionary(e => e.Key, e => e.Value);
            Console.WriteLine($"{legendariElements[obtainedElement]} obtained!");

            foreach(var item in sortedElements)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in sortedjunkElements)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");

            }
        }
    }
}
