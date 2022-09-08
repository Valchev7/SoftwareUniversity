using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendListM
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friends = Console.ReadLine()
                 .Split(", ")
                 .ToList();

            string input = Console.ReadLine();
            int blacklistedNamesCounter = 0;
            int lostNamesCounter = 0;

            while (input != "Report")
            {
                string[] allCommands = input.Split();
                string command = allCommands[0];

                switch (command)
                {
                    case "Blacklist": 
                        string name = allCommands[1];

                        for (int i = 0; i < friends.Count; i++)
                        {
                            if (!friends.Contains(name))
                            {
                                Console.WriteLine($"{name} was not found.");
                                break;
                            }
                            if (friends[i] == name)
                            {
                                blacklistedNamesCounter++;
                                Console.WriteLine($"{friends[i]} was blacklisted.");
                                friends[i] = "Blacklisted";
                                break;
                            }
                        }
                        break;
                    case "Error":
                        int index = int.Parse(allCommands[1]);
                        if (index >= 0 && index < friends.Count && friends[index] != "Blacklisted" && friends[index] != "Lost")
                        {
                            Console.WriteLine($"{friends[index]} was lost due to an error.");
                            friends[index] = "Lost";
                            lostNamesCounter++;
                        }
                        break;
                    case "Change":
                        int ind = int.Parse(allCommands[1]);
                        string newName = allCommands[2];

                        if (ind >= 0 && ind < friends.Count)
                        {
                            string currName = friends[ind];
                            friends[ind] = newName;
                            Console.WriteLine($"{currName} changed his username to {newName}.");
                        }
                        break;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Blacklisted names: { blacklistedNamesCounter}");
            Console.WriteLine($"Lost names: {lostNamesCounter}");
            Console.WriteLine(String.Join(" ", friends));
        }
    }
}