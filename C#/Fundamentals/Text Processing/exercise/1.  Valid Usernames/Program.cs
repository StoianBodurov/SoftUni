using System;
using System.Collections.Generic;

namespace _1.__Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(", ");
            List<string> result = new List<string>();

            foreach (string username in data)
            {
                if (isValid(username))
                {
                    result.Add(username);
                }

            }
            Console.WriteLine(string.Join("\n", result));
        }

        private static bool isValid(string username)
        {
            if (username.Length < 3 || username.Length > 16)
            {
                return false;
            }

            for (int i = 0; i < username.Length; i++)
            {
                char ch = username[i];
                if (!(char.IsDigit(ch) || char.IsLetter(ch) || ch == '-' || ch == '_'))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
