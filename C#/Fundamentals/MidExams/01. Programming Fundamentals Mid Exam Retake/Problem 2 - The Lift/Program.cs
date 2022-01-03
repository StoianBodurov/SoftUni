using System;
using System.Linq;

namespace Problem_2___The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int maximumCapacity = 4;

            for (int i = 0; i < lift.Length; i++)
            {
                int freeSpace = maximumCapacity - lift[i];
                if (freeSpace > 0)
                {
                    if (people >= freeSpace)
                    {
                        lift[i] += freeSpace;
                        people -= freeSpace;
                    }
                    else
                    {
                        lift[i] += people;
                        people = 0;
                    }
                }
            }

            if (people == 0)
            {
                if (!lift.All(x => x == maximumCapacity))
                {
                    Console.WriteLine("The lift has empty spots!");
                }
    
            }
            else
            {
                if (lift.All(x => x == maximumCapacity))
                {
                    Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                }

            }
            Console.WriteLine(string.Join(" ", lift));

        }
    }
}
