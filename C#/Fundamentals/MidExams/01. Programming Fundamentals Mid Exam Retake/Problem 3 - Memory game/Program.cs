using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Memory_game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().ToList();
            int countMoves = 0;

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "end")
                {
                    break;
                }

                int firstIndex = int.Parse(command[0]);
                int secondIndex = int.Parse(command[1]);
                countMoves++;

                if (firstIndex < 0 || firstIndex >= elements.Count || secondIndex < 0 || secondIndex >= elements.Count || firstIndex == secondIndex)
                {
                    int index = elements.Count / 2;
                    elements.Insert(index, "-"+countMoves.ToString()+"a");
                    elements.Insert(index, "-"+countMoves.ToString()+"a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    continue;
                }

                if (elements[firstIndex] == elements[secondIndex])
                {
                    string element = elements[firstIndex];
                    Console.WriteLine($"Congrats! You have found matching elements - {element}!");
                    elements.Remove(element);
                    elements.Remove(element);
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {countMoves} turns!");
                    break;
                }
            }

            if (elements.Count > 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", elements));
            }
        }
    }
}
