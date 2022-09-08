using System;
using System.Text;

namespace StringManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder(input);

            string[] command = Console.ReadLine().Split(" ");

            while (command[0] != "End")
            {
                if (command[0] == "Translate")
                {
                    sb.Replace(command[1], command[2]);
                    Console.WriteLine(sb);
                }
                else if (command[0] == "Includes")
                {
                    if (sb.ToString().Contains(command[1]))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command[0] == "Start")
                {
                    int len = command[1].Length;
                    if (command[1] == sb.ToString().Substring(0, len))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command[0] == "Lowercase")
                {
                    for (int i = 0; i < sb.ToString().Length - 1; i++)
                    {
                        sb[i] = char.Parse(sb[i].ToString().ToLower());
                    }
                    Console.WriteLine(sb);
                }
                else if (command[0] == "FindIndex")
                {
                    Console.WriteLine(sb.ToString().LastIndexOf(command[1]));
                }
                else if (command[0] == "Remove")
                {
                    sb.Remove(int.Parse(command[1]), int.Parse(command[2]));
                    Console.WriteLine(sb);
                }

                command = Console.ReadLine().Split(" ");
            }
        }
    }
}