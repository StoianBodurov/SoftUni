using System;

namespace Problem_1___Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            int count = 0;
            bool isWon = true;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End of battle")
                {
                    break;
                }
                

                int distance = int.Parse(command);

                if (initialEnergy >= distance)
                {
                    initialEnergy -= distance;
                    count++;
                    
                }
                else
                {
                   
                    isWon = false;
                    break;
                }
                if (count % 3 == 0)
                {
                    initialEnergy += count;
                }

            }

            if (isWon)
            {
                Console.WriteLine($"Won battles: {count}. Energy left: {initialEnergy}");
            }

            else
            {
                Console.WriteLine($"Not enough energy! Game ends with {count} won battles and {initialEnergy} energy");
            }
        }
    }
}
