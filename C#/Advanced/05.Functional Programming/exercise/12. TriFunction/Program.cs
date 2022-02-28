using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Func<string, bool> getFirstName = name => FilterName(name, n);
            string names = Console.ReadLine().Split(" ").Where(n => getFirstName(n)).FirstOrDefault();
            Console.WriteLine(names);
            
        }

        public static bool FilterName(string name, int sum)
        {
            int charSum = 0;
            for(int i = 0; i < name.Length; i++)
            {
                charSum += name[i];
            }
            if (charSum >= sum)
            {
                return true;
            }
            return false;
        }
    }
}
