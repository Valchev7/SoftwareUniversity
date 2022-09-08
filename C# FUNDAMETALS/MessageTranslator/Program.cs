using System;
using System.Text.RegularExpressions;

namespace MessageTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Regex pattern = new Regex(@"\!([A-Z][a-z]{2,})\!\:\[([a-zA-z]{8,})\]");

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = pattern.Match(input);

                if (match.Success)
                {
                    string name = match.Groups[2].ToString();
                    string nums = string.Empty;
                    for (int j = 0; j < name.Length; j++)
                    {
                        int digit = name[j];
                        nums += digit + " ";

                    }
                    Console.WriteLine($"{match.Groups[1]}: {nums}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}