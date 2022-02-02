using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>(data);

            while (true)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0].ToLower() == "end")
                {
                    break;
                }

                if (command[0].ToLower() == "add")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        numbers.Push(int.Parse(command[i]));
                    }
                }
                else if (command[0].ToLower() == "remove")
                {
                    int count = int.Parse(command[1]);
                    if (numbers.Count < count)
                    {
                        continue;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        numbers.Pop();
                    }
                }
            }
            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
