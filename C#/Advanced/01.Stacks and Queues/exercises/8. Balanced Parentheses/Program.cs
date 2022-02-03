using System;
using System.Collections.Generic;

namespace _8._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            bool isBalanced = true;
            Dictionary<char, char> parentheses = new Dictionary<char, char>();
            parentheses.Add('(', ')');
            parentheses.Add('{', '}');
            parentheses.Add('[', ']');

            Queue<char> queue = new Queue<char>(data);
            Stack<char> stack = new Stack<char>(data);

            if (data.Length % 2 == 0)
            {
                for(int i = 0; i < data.Length / 2; i++)
                {
                    char firstElement = queue.Dequeue();
                    char lastElement = stack.Pop();

                    if (lastElement != parentheses[firstElement])
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }
            else
            {
                isBalanced = false;
            }
            

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
            


        }
    }
}
