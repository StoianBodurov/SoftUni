using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Students
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>();
            while (true)
            {
                string[] data = Console.ReadLine().Split();
                if (data[0] == "end")
                {
                    break;
                }

                string firstName = data[0];
                string lastName = data[1];
                int age = int.Parse(data[2]);
                string hometown = data[3];

                Student studen = new Student
                {
                    FisrtName = firstName,
                    LastName = lastName,
                    Age = age,
                    City = hometown,
                };


                students.Add(studen);


            }

            string cityName = Console.ReadLine();

            List<Student> filterdStudents = students
                .Where(s => s.City == cityName)
                .ToList();

            foreach (var student in filterdStudents)
            {
                Console.WriteLine($"{student.FisrtName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}
