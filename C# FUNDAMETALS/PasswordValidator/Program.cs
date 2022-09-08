using System;
using System.Linq;

namespace ConsoleApp80
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (Validator(password) == true)
            {
                Console.WriteLine("Password is valid");
            }


        }

        static bool Validator(string input)
        {
            bool length = PasswordLength(input);
            bool chars = IsAllLettersOrDigits(input);
            bool numbers = DigitCount(input);

            if (length == true && chars == true && numbers == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool PasswordLength(string input)
        {
            if (input.Length < 6 || input.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool IsAllLettersOrDigits(string input)
        {
            if (!input.All(Char.IsLetterOrDigit))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                return false;
            }
            else
            {
                return true;
            }
        }

        static bool DigitCount(string input)
        {
            if (!(input.Count(Char.IsDigit) >= 2))
            {
                Console.WriteLine("Password must have at least 2 digits");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}