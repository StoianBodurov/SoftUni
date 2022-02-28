using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ").ToList();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ");
                string command = commands[0];
                if (command == "Party!")
                {
                    break;
                }

                string criteria = commands[1];
                string givenString = commands[2];

                switch (command)
                {
                    case "Remove":
                        guests = guests.Where(name => RemoveGuests(name, criteria, givenString)).ToList();
                        break;
                    case "Double":
                        DoubleGuests(guests, criteria, givenString);
                        break;
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void DoubleGuests(List<string> guests, string criteria, string givenString)
        {
            for(int i = 0; i < guests.Count; i++)
            {
                bool getCriteria = false;
                string guest = guests[i];
                switch (criteria)
                {
                    case "StartsWith":
                        if (guest.StartsWith(givenString))
                        {
                            getCriteria = true;
                        }
                        break;
                    case "EndsWith":
                        if (guest.EndsWith(givenString))
                        {
                            getCriteria = true;
                        }
                        break;
                    case "Length":
                        int length = int.Parse(givenString);
                        if (guest.Length == length)
                        {
                            getCriteria = true;
                        }
                        break;
                }
                if (getCriteria)
                {
                    guests.Insert(i, guest);
                }
                i++;
            }
        }

        private static bool RemoveGuests(string name, string criteria, string givenString)
        {
            switch(criteria)
            {
                case "StartsWith":
                    return !name.StartsWith(givenString);
                case "EndsWith":
                    return !name.EndsWith(givenString);
                case "Length":
                    int length = int.Parse(givenString);
                    return !(name.Length == length);

            }

            return true;
        }
    }
}
