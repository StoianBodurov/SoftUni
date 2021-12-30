using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Students_2._0
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

                if (!IsStudentExisting(students, firstName, lastName))
                {
                    Student student = new Student
                    {
                        FisrtName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = hometown,
                    };
                    students.Add(student);
                }

                else
                {
                    Student currentStudent = GetStudent(students, firstName, lastName);
                    currentStudent.Age = age;
                    currentStudent.City = hometown;
                }
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

        static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;
            foreach (var student in students)
            {
                if (student.FisrtName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }

        static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FisrtName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
