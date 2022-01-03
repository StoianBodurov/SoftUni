using System;

namespace Problem_1___SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int fullEfficiency = 0;
            for (int i = 0; i < 3; i++)
            {
                int efficiency = int.Parse(Console.ReadLine());
                fullEfficiency += efficiency;
            }
            int studentsCount = int.Parse(Console.ReadLine());

            int hours = 0;
            int breakcount = 1;
            while (true)
            {
                if (studentsCount <= 0)
                {
                    break;
                }

                if (breakcount % 4 == 0)
                {
                    breakcount = 1;
                    hours++;
                    continue;
                }
                studentsCount -= fullEfficiency;
                hours++;
                breakcount++;
            }
            

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
