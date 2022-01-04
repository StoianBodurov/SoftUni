using System;
using System.Linq;

namespace Problem_2___Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];

                if (command == "end")
                {
                    break;
                }

                if (command == "swap")
                {
                    int index1 = int.Parse(commands[1]);
                    int index2 = int.Parse(commands[2]);

                    int temp = data[index1];
                    data[index1] = data[index2];
                    data[index2] = temp; 

                }
                else if (command == "multiply")
                {
                    int index1 = int.Parse(commands[1]);
                    int index2 = int.Parse(commands[2]);
                    int result = data[index1] * data[index2];

                    data[index1] = result;
                }
                else
                {
                    for(int i = 0; i < data.Length; i++)
                    {
                        data[i] -= 1;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", data));
        }
    }
}
