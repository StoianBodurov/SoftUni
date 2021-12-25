using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Change_List
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
                    case "Delete":
                        int number = int.Parse(commands[1]);
                        data.RemoveAll(n => n == number);
                        break;
                    case "Insert":
                        number = int.Parse(commands[1]);
                        int index = int.Parse(commands[2]);
                        data.Insert(index, number);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", data));
        }
    }
}
