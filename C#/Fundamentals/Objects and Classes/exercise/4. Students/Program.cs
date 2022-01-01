using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string firstName = data[0];
                string lastName = data[1];
                double grade = double.Parse(data[2]);

                Student student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Grade = grade,
                };
                students.Add(student);
            }

            students.Sort((x, y) => y.Grade.CompareTo(x.Grade));

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
