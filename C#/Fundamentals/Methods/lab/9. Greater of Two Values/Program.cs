using System;

namespace _9._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string value1 = Console.ReadLine();
            string value2 = Console.ReadLine();

            if (type == "int")
            {
                int num1 = int.Parse(value1);
                int num2 = int.Parse(value2);

                Console.WriteLine(GetMax(num1, num2));
            }
            else if(type == "char")
            {
                char char1 = char.Parse(value1);
                char char2 = char.Parse(value2);

                Console.WriteLine(GetMax(char1, char2));
            }
            else if (type == "string")
            {
                Console.WriteLine(GetMax(value1, value2));
            }
        }

        static string GetMax(string value1, string value2)
        {
            int result = value1.CompareTo(value2);
            if (result > 0)
            {
                return value1;
            }
            return value2;
        }

        static int GetMax(int num1, int num2)
        {
            if ( num1 > num2)
            {
                return num1;
            }
            return num2;
        }

        static char GetMax(char char1, char char2)
        {
            if (char1 > char2)
            {
                return char1;
            }
            return char2;
        }
    
    }
}
