using System;
using System.Collections.Generic;

namespace _7._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            while (true)
            {
                string[] data = Console.ReadLine().Split();

                if (data[0] == "End")
                {
                    break;
                }

                string name = data[0];
                string id = data[1];
                int age = int.Parse(data[2]);

                Person person = new Person
                {
                    Name = name,
                    Id = id,
                    Age = age,
                };

                persons.Add(person);
            }

            persons.Sort((x, y) => x.Age.CompareTo(y.Age));

            foreach (Person p in persons)
            {
                Console.WriteLine($"{p.Name} with ID: {p.Id} is {p.Age} years old.");
            }
        }
    }
}
