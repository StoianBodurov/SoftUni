using System;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Func<int, int> Add = n => n + 1;
            Func<int, int> Multiplay = n => n * 2;
            Func<int, int> Subtract = n => n - 1;
            Action<int[]> Print = n => Console.WriteLine(string.Join(" ", n));

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(Add).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(Multiplay).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(Subtract).ToArray();
                        break;
                    case "print":
                        Print(numbers);
                        break;

                }
            } 
        }
    }
}
