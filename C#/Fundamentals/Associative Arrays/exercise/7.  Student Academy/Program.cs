using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.__Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>(); 

            for (int i = 0; i < n; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<double>());
                }

                students[studentName].Add(grade);
            }

            Dictionary<string, List<double>> filterdStudents = students
                .Where(s => s.Value.Average() >= 4.5)
                .OrderByDescending(s => s.Value.Average())
                .ToDictionary(s => s.Key, s => s.Value);

            foreach (var item in filterdStudents)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }
        }
    }
}
