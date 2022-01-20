using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Cinema
{
    class Program
    {
        private static object index;

        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split(", ").ToList();
            string[] result = new string[data.Count];
            bool[] used = new bool[data.Count];

            while (true)
            {
                string[] command = Console.ReadLine().Split(" - ");

                if (command[0] == "generate")
                {
                    break;
                }

                string name = command[0];
                int place = int.Parse(command[1]) - 1;
                result[place] = name;
                used[place] = true;
                data.Remove(name);
            }

            List<string> variation = new List<string>();

            GetResult(0, data, variation);
           foreach (var el in variation)
            {
                var v = el.Split().ToList();
               for(int i = 0; i < used.Length; i++)
                {
                
                    if (!used[i])
                    {
                        result[i] = v[0];
                        v.RemoveAt(0);
                    }
                } 
                Console.WriteLine(string.Join(" ", result));

            }

        }

        private static void GetResult(int index, List<string> data, List<string> variation)
        {
            if (index >= data.Count)
            {
            
                variation.Add(string.Join(" ", data));

            }
            else
            {
                GetResult(index + 1, data, variation);
                for (int i = index + 1; i < data.Count; i++)
                {


                    Swap(index, i, data);
                    GetResult(index + 1, data, variation);
                    Swap(index, i, data);
                    
                    
                }

            }
        }

        private static void Swap(int index, int i, List<string> data)
        {
            string temp = data[index];
            data[index] = data[i];
            data[i] = temp;
        }
    }
}
