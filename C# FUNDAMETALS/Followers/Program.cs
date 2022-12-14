using System;
using System.Collections.Generic;
using System.Linq;

namespace EP03.Followers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> followers = new Dictionary<string, int[]>();

            string command = Console.ReadLine();

            while (command != "Log out")
            {
                string[] split = command.Split(": ");
                if (command.Contains("New follower"))
                {
                    if (!followers.ContainsKey(split[1]))
                    {
                        followers.Add(split[1], new int[2]);
                    }
                }
                else if (command.Contains("Like"))
                {
                    int likes = int.Parse(split[2]);
                    if (!followers.ContainsKey(split[1]))
                    {
                        followers.Add(split[1], new int[2] { likes, 0 });
                    }
                    else
                    {
                        followers[split[1]][0] += likes;
                    }
                }
                else if (command.Contains("Comment"))
                {
                    if (!followers.ContainsKey(split[1]))
                    {
                        followers.Add(split[1], new int[2] { 0, 1 });
                    }
                    else
                    {
                        followers[split[1]][1] += 1;
                    }
                }
                else if (command.Contains("Blocked"))
                {
                    if (followers.ContainsKey(split[1]))
                    {
                        followers.Remove(split[1]);
                    }
                    else
                    {
                        Console.WriteLine($"{split[1]} doesn't exist.");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{followers.Count} followers");

            followers = followers.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var follower in followers)
            {
                Console.WriteLine($"{follower.Key}: {follower.Value[0] + follower.Value[1]}");
            }
        }
    }
}