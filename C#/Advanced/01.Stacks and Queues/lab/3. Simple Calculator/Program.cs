using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            Stack<int> numbers = new Stack<int>();
            Stack<char> operations = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsDigit(expression[i]))
                {
                    StringBuilder simbol = new StringBuilder();
                    simbol.Append(expression[i]);
                    i++;
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        simbol.Append(expression[i]);
                        i++;
                    }
                    i--;
                    numbers.Push(int.Parse(simbol.ToString()));
                }
                else if (expression[i] == '+' || expression[i] == '-')
                {
                    operations.Push(expression[i]);
                }
            }
            

            
            operations = ReveraStack(operations);
            numbers = ReveraStack(numbers);

            while (operations.Count > 0)
            {
                char operatoion = operations.Pop();
                int num1 = numbers.Pop();
                int num2 = numbers.Pop();

                int result = 0;
                switch (operatoion)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;

                }

                numbers.Push(result);
                
            }

            Console.WriteLine(numbers.Pop());
        }

        private static Stack<int> ReveraStack(Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();
            foreach(var el in stack)
            {
                temp.Push(el);
            }
            return temp;
        }

        private static Stack<char> ReveraStack(Stack<char> stack)
        {
            Stack<char> temp = new Stack<char>();
            foreach (var el in stack)
            {
                temp.Push(el);
            }

            return temp;
        }
    }   
}
