using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Coffee_Lover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine().Split().ToList();

            int cmdCount = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 0; i < cmdCount; i++)
            {
                string[] commands = Console.ReadLine().Split().ToArray();

                if (commands[0] == "Include")
                {
                    coffees.Add(commands[1]);
                }
                if (commands[0] == "Remove")
                {
                    if (commands[1] == "first")
                    {
                        //if (int.Parse(commands[2]) > coffees.Count)
                        //{

                        //}
                        //else
                        //{
                        for (int j = 0; j < int.Parse(commands[2]); j++)
                        {
                            coffees.RemoveAt(j);
                            //j--;
                            //counter++;
                            //if (counter == int.Parse(commands[2]))
                            //{
                            //    break;
                            //}
                        }

                        // }
                    }
                    if (commands[1] == "last")
                    {
                        //if (int.Parse(commands[2]) > coffees.Count)
                        //{

                        //}
                        //else
                        //{
                        counter = 0;
                        for (int k = 0; k < int.Parse(commands[2]); k++)
                        {
                            coffees.RemoveAt(coffees.Count - 1);
                            //counter++;
                            //if (counter == int.Parse(commands[2]))
                            //{
                            //    break;
                            //}
                        }
                        //}
                    }
                }
                if (commands[0] == "Prefer")
                {
                    int firstIndex = int.Parse(commands[1]);
                    int secondIndex = int.Parse(commands[2]);
                    if (firstIndex >= 0 && firstIndex < coffees.Count && secondIndex >= 0 && secondIndex < coffees.Count)
                    {

                        string test = coffees[firstIndex];
                        coffees[firstIndex] = coffees[secondIndex];
                        coffees[secondIndex] = test;

                    }
                }
                if (commands[0] == "Reverse")
                {
                    coffees.Reverse();
                }
            }
            Console.WriteLine($"Coffees: ");
            Console.WriteLine(string.Join(" ", coffees));
        }
    }
}
