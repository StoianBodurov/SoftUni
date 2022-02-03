using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int countElementsToPush = commands[0];
            int countElementsToPop = commands[1];
            int searchedElement = commands[2];
            Stack<int> stack = new Stack<int>();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < countElementsToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < countElementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                if (stack.Contains(searchedElement))
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}
