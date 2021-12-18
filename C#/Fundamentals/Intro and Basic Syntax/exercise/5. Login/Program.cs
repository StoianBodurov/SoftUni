using System;

namespace _5._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            int count = 0;

            while (true)
            {
                count++;
                string passwordInput = Console.ReadLine();
                string password = "";

                for (int i = passwordInput.Length - 1; i >= 0; i--)
                {
                    password += passwordInput[i];
                }
                if (password == userName)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
                else
                {
                    if (count == 4)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                        break;
                    }
                    else
                    {
                    Console.WriteLine("Incorrect password. Try again.");

                    }
                }
               
            }
            
        }
    }
}
