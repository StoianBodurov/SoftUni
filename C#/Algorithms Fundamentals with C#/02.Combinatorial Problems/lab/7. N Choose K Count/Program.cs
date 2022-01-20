using System;

namespace _7._N_Choose_K_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Console.WriteLine(GetChoose(n, k));
        }

        private static long GetChoose(int n, int k)
        {
            if (n <= 1 || k == 0 || k == n)
            {
                return 1;
            }
            return GetChoose(n - 1, k) + GetChoose(n - 1, k - 1);
        }
    }
}
