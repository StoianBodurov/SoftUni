using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int boxCapacity = int.Parse(Console.ReadLine());
            int capacityLeft = boxCapacity;
            int boxCount = 1;

            while (clothes.Count > 0)
            {
                
                int cloths = clothes.Pop();
                if (cloths <= capacityLeft)
                {
                    capacityLeft -= cloths;
                }
                else
                {
                    capacityLeft = boxCapacity - cloths;
                    boxCount++;
                }
            }

            Console.WriteLine(boxCount);

        }
    }
}
