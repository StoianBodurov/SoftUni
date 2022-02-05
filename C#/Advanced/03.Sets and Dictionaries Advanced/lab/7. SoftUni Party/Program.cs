using System;
using System.Collections.Generic;

namespace _7._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            while (true)
            {
                string student = Console.ReadLine();
                if (student == "PARTY")
                {
                    break;
                }

                if (char.IsDigit(student[0]))
                {
                    vip.Add(student);
                }
                else
                {
                    regular.Add(student);
                }
            }

            while (true)
            {
                string student = Console.ReadLine();
                if (student == "END")
                {
                    break;
                }

                if (vip.Contains(student))
                {
                    vip.Remove(student);
                }

                if (regular.Contains(student))
                {
                    regular.Remove(student);
                }
            }

            Console.WriteLine(vip.Count + regular.Count);
            

            

            foreach(var el in vip)
            {
                Console.WriteLine(el);
            }

            foreach(var el in regular)
            {
                Console.WriteLine(el);
            }
        }
    }
}
