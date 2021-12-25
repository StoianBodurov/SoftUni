using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstList = Console.ReadLine().Split().ToList();
            List<string> secondtList = Console.ReadLine().Split().ToList();
            List<string> result = new List<string>();
 

            if (secondtList.Count() > firstList.Count())
            {
                for (int i = 0; i < secondtList.Count(); i++)
                {
                    if (firstList.Count() > i)
                    {
                        result.Add(firstList[i]);
                    }
                    result.Add(secondtList[i]);
                }
            }
            else
            {
                for (int i = 0; i < firstList.Count(); i++)
                {
                    result.Add(firstList[i]);
                    if (secondtList.Count() > i)
                    {
                        result.Add(secondtList[i]);
                    }
                }
            }
            Console.WriteLine(string.Join(' ', result));


        }
    }
}
