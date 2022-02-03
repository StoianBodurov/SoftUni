using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int countElementsToAdd = commands[0];
            int countElementsToRemoved = commands[1];
            int searchedElement = commands[2];
            Queue<int> queue = new Queue<int>();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < countElementsToAdd; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < countElementsToRemoved; i++)
            {
                if (queue.Count > 0)
                {
                    queue.Dequeue();

                }
            }

            if (queue.Count > 0)
            {
                if (queue.Contains(searchedElement))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }


        }
    }
}
