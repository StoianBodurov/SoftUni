using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] token = Console.ReadLine().Split(" -> ");

                if (token[0] == "End")
                {
                    break;
                }

                string company = token[0];
                string employId = token[1];

                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new List<string>());
                }

                if (!companies[company].Contains(employId))
                {
                    companies[company].Add(employId);

                }
            }

            Dictionary<string, List<string>> sortedCompanies = companies.OrderBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);

            foreach (var item in sortedCompanies)
            {
                Console.WriteLine(item.Key);

                foreach (var id in item.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
