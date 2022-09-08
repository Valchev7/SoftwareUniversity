using System;
using System.Collections.Generic;
using System.Linq;

namespace DegustationParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split("-");
            Dictionary<string, List<string>> guestsAndMeals = new Dictionary<string, List<string>>();
            int counter = 0;

            while (commands[0] != "Stop")
            {
                if (commands[0] == "Like")
                {
                    if (!guestsAndMeals.ContainsKey(commands[1]))
                    {
                        guestsAndMeals.Add(commands[1], new List<string>());

                    }

                    if (guestsAndMeals[commands[1]].Contains(commands[2]))
                    {
                        commands = Console.ReadLine().Split();
                        continue;
                    }
                    else
                    {
                        guestsAndMeals[commands[1]].Add(commands[2]);
                    }



                }
                else if (commands[0] == "Dislike")
                {
                    if (!guestsAndMeals.ContainsKey(commands[1]))
                    {
                        Console.WriteLine($"{commands[1]} is not at the party.");
                    }
                    else if (!guestsAndMeals[commands[1]].Contains(commands[2]))
                    {
                        Console.WriteLine($"{commands[1]} doesn't have the {commands[2]} in his/her collection.");
                    }
                    else
                    {
                        guestsAndMeals[commands[1]].Remove(commands[2]);
                        counter++;
                        Console.WriteLine($"{commands[1]} doesn't like the {commands[2]}.");
                    }
                }

                commands = Console.ReadLine().Split("-");
            }

            foreach (var guest in guestsAndMeals.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value)}");
            }

            Console.WriteLine($"Unliked meals: {counter}");
        }
    }
}