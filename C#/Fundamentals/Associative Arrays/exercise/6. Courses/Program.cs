using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] token = Console.ReadLine().Split(" : ");

                if (token[0] == "end")
                {
                    break;
                }

                string coursName = token[0];
                string studentName = token[1];

                if (!courses.ContainsKey(coursName))
                {
                    courses.Add(coursName, new List<string>());
                }

                courses[coursName].Add(studentName);
            }

            Dictionary<string, List<string>> sortedCourses = courses.OrderByDescending(c => c.Value.Count).ToDictionary(c => c.Key, c => c.Value);
            foreach(var item in sortedCourses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                item.Value.Sort((x, y) => x.CompareTo(y));

                foreach(string student in item.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
