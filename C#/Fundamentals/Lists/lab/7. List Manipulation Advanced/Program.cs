using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> data = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                List<string> commands = Console.ReadLine().Split().ToList();
                if (commands[0] == "end")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "Contains":
                        int number = int.Parse(commands[1]);
                        Contains(data, number);
                        break;
                    case "PrintEven":
                        PrintEven(data);
                        break;
                    case "PrintOdd":
                        PrintOdd(data);
                        break;
                    case "GetSum":
                        GetSum(data);
                        break;
                    case "Filter":
                        string condition = commands[1];
                        number = int.Parse(commands[2]);
                        Filter(data, condition, number);

                        break;
                }
            }
        }

        private static void Filter(List<int> data, string condition, int number)
        {
            List<int> result = new List<int>();
            switch (condition)
            {
                case "<":
                    result = data.FindAll(n => n < number);
                    break;
                case "<=":
                    result = data.FindAll(n => n <= number);
                    break;
                case ">":
                    result = data.FindAll(n => n > number);
                    break;
                case ">=":
                    result = data.FindAll(n => n >= number);
                    break;
            }

            Console.WriteLine(string.Join(" ", result));

        }

        static void GetSum(List<int> data)
        {
            Console.WriteLine(data.Sum());
        }

        static void PrintOdd(List<int> data)
        {
            List<int> result = data.FindAll(n => n % 2 != 0);
            Console.WriteLine(string.Join(" ", result));
        }

        static void PrintEven(List<int> data)
        {
            List<int> result = data.FindAll(n => n % 2 == 0);
            Console.WriteLine( string.Join(" ", result));
        }

        static void Contains(List<int> data, int number)
        {
            if (data.Contains(number))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }
    }
}
