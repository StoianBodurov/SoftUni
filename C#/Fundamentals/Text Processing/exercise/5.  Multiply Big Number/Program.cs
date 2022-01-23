using System;
using System.Text;

namespace _5.__Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            int multiplyer = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            int reminder = 0;

            for (int i = data.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(data[i].ToString());
                int product = digit * multiplyer + reminder;
                int currentResult = product % 10;
                reminder = product / 10;

                result.Insert(0, currentResult);
            }

            if (reminder > 0)
            {
                result.Insert(0, reminder);
            }
            Console.WriteLine(result);
        }
    }
}
