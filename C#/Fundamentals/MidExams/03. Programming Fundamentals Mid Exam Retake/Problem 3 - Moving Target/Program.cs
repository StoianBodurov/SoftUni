using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] token = Console.ReadLine().Split();
                string command = token[0];

                if (command == "End")
                {
                    break;
                }

                int index = int.Parse(token[1]);

                if (command == "Shoot")
                {
                    if (index >= 0 && index < targets.Count)
                    {
                        int power = int.Parse(token[2]);
                        targets[index] -= power;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if ( command == "Add") 
                {
                    if (index >= 0 && index < targets.Count)
                    {
                        int value = int.Parse(token[2]);
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (command == "Strike")
                {
                    int radius = int.Parse(token[2]);
                    int minIndex = index - radius;
                    int maxIndex = index + radius;

                    if (minIndex < 0 || maxIndex > targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        targets.RemoveRange(minIndex, maxIndex - minIndex + 1);
                    }
                }
                
            }

            Console.WriteLine(string.Join("|", targets));

        }
    }
}
