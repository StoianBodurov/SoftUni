using System;

namespace _4._Password_Validator_
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            ValidatePassword(password);
        }

        static void ValidatePassword(string password)
        {
            bool isValid = true;
           if ( CheckPasswordLength(password))
            {
                isValid = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
           if (CheckPasswordConsist(password))
            {
                isValid = false;
                Console.WriteLine("Password must consist only of letters and digits");
            }
           if (CheckForCorrectDigitCount(password))
            {
                isValid = false;
                Console.WriteLine("Password must have at least 2 digits");
            }
           if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool CheckForCorrectDigitCount(string password)
        {
            int digitCount = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    digitCount += 1;
                }
            }

            return digitCount < 2;
        }

        static bool CheckPasswordConsist(string password)
        {
            bool isCorrect = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (!((password[i] >= 48 && password[i] <= 57) || (password[i] >= 65 && password[i] <= 90) || (password[i] >= 97 && password[i] <= 122)))
                {
                    isCorrect = true;
                    break;
                }
            }

            return isCorrect;
        }

        static bool CheckPasswordLength(string password)
        {
            return (password.Length < 6 || password.Length > 10);
        }
    }
}
