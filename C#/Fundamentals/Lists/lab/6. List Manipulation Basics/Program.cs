    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace _6._List_Manipulation_Basics
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> data = Console.ReadLine().Split().Select(int.Parse).ToList();

                while (true)
                {
                    List<string> command = Console.ReadLine().Split().ToList();
                    if (command[0] == "end")
                    {
                        break;
                    }

                    if (command[0] == "Add")
                    {
                        int number = int.Parse(command[1]);
                        Add(data, number);
                    }
                    else if (command[0] == "Remove")
                    {
                        int number = int.Parse(command[1]);
                        Remove(data, number);
                    }
                    else if(command[0] == "RemoveAt")
                    {
                        int index = int.Parse(command[1]);
                        RemoveAt(data, index);
                    }
                    else if (command[0] == "Insert")
                    {
                        int number = int.Parse(command[1]);
                        int index = int.Parse(command[2]);

                        Insert(data, index, number);
                    }

                }
                    Console.WriteLine(string.Join(" ", data));
            }

            static void Insert(List<int> data, int index, int number)
            {
                data.Insert(index, number); 
            }

            static void RemoveAt(List<int> data, int index)
            {
                data.RemoveAt(index);
            }

            static void Remove(List<int> data, int number)
            {
                data.Remove(number);
            }

            static void Add(List<int> data, int n)
            {
                data.Add(n);
            }
        }
    }
