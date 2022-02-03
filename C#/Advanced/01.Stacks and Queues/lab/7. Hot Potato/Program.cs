using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] persons = Console.ReadLine().Split();
            Queue<string> queue = new Queue<string>(persons);
            int n = int.Parse(Console.ReadLine());
            int count = 1;

            while (queue.Count > 1)
            {
                if (count >= n)
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                    count = 1;
                }
                else
                {

                    queue.Enqueue(queue.Dequeue());
                    count++;
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");

        }
    }
}
