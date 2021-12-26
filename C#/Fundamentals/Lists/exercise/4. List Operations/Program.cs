using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                List<string> tokens = Console.ReadLine().Split().ToList();
                string command = tokens[0];

                if (command == "End")
                {
                    break;
                }

                switch (command)
                {
                    case "Add":
                        int number = int.Parse(tokens[1]);
                        numbers.Add(number);
                        break;
                    case "Insert":
                        number = int.Parse(tokens[1]);
                        int index = int.Parse(tokens[2]);
                        if (CorerctIndex(numbers, index))
                        {
                            numbers.Insert(index, number);
                            break;
                        }
                        Console.WriteLine("Invalid index");
                        break;
                    case "Remove":
                        index = int.Parse(tokens[1]);
                        if (CorerctIndex(numbers , index))
                        {
                            numbers.RemoveAt(index);
                            break;

                        }
                        Console.WriteLine("Invalid index");
                        break;
                    case "Shift":
                        string position = tokens[1];
                        int count = int.Parse(tokens[2]);
                        Shift(numbers, position, count);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        static bool CorerctIndex(List<int> numbers, int index)
        {
            if (index >= 0 &&  index < numbers.Count())
            {
                return true;
            }
            return false;
        }

        static void Shift(List<int> numbers, string position, int count)
        {
            if (position == "left")
            {
                ShiftLeft(numbers, count);
            }
            else
            {
                ShiftRight(numbers, count);

            }
        }

         static void ShiftRight(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int temp = numbers[numbers.Count() - 1];
                numbers.RemoveAt(numbers.Count() - 1);
                numbers.Insert(0, temp);
            }
        }

        static void ShiftLeft(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int temp = numbers[0];
                numbers.RemoveAt(0);
                numbers.Add(temp);
            }
        }
    }
}
