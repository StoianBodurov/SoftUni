using System;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] people = new int[wagons];
            int sum = 0;

            for (int i = 0; i < wagons; i++)
            {
                int countOfPeople = int.Parse(Console.ReadLine());
                sum += countOfPeople;
                people[i] = countOfPeople;
            }

            Console.WriteLine(string.Join(' ', people));
            Console.WriteLine(sum);
        }
    }
}
