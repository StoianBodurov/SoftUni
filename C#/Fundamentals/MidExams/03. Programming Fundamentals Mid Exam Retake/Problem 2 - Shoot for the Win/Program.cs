using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2___Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> shotTarget = new List<int>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                int target = int.Parse(command);
                if (target < 0 || target >= targets.Length) 
                {
                    continue;
                }

                int tempValue = targets[target];

                if (!shotTarget.Contains(target))
                {
                    targets[target] = -1;
                    shotTarget.Add(target);
                }

                for (int i = 0; i < targets.Length; i++)
                {
                    if (shotTarget.Contains(i))
                    {
                        continue;
                    }
                    if (targets[i] > tempValue)
                    {
                        targets[i] -= tempValue;
                    }
                    else
                    {
                        targets[i] += tempValue;
                    }
                }
            }

            Console.WriteLine($"Shot targets: {shotTarget.Count()} -> {string.Join(" ", targets)}");
        }
    }
}
