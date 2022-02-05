using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                decimal grade = decimal.Parse(data[1]);
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                }

                students[name].Add(grade);
            }

            foreach (var pair in students)
            {
                string name = pair.Key;
                List<string> gradeToString = new List<string>();
                decimal avarageGrade = pair.Value.Sum() / pair.Value.Count;

                foreach(var el in pair.Value)
                {
                    gradeToString.Add(el.ToString("0.00"));
                }

                Console.WriteLine($"{name} -> {string.Join(" ", gradeToString)} (avg: {avarageGrade:f2})");
            }


        }
    }
}
