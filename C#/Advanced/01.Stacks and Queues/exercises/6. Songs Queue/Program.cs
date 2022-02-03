using System;
using System.Collections.Generic;

namespace _6._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> playList = new Queue<string>(Console.ReadLine().Split(", "));

            while (playList.Count > 0)
            {
                string[] commands = Console.ReadLine().Split(" ", 2);
                string command = commands[0];

                switch (command)
                {
                    case "Play":
                        playList.Dequeue();
                        break;
                    case "Add":
                        string song = commands[1];
                        if (playList.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                            break;
                        }
                        playList.Enqueue(song);
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", playList));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
