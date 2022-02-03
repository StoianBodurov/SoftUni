using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int command = commands[0];

                switch (command)
                {
                    case 1:
                        numbers.Push(commands[1]);
                        break;
                    case 2:
                        if (numbers.Count > 0)
                        {
                            numbers.Pop();
                        }
                        break;
                    case 3:
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        break;
                    case 4:
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        break;

                }

            }
            
            while (numbers.Count > 0)
            {
                if (numbers.Count == 1)
                {
                    Console.Write(numbers.Pop());

                }
                else
                {
                    Console.Write($"{numbers.Pop()}, ");
                }
            }
            Console.WriteLine();
        }
    }
}
