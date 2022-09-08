using System;
using System.Collections.Generic;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allGroceries = new List<string>(Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries));
            string command = Console.ReadLine();
            while (command.ToLower() != "go shopping!")
            {
                string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currentCommand = commandArray[0].ToLower();
                switch (currentCommand)
                {
                    case "urgent":
                        string item = commandArray[1];
                        if (!allGroceries.Contains(item))
                        {
                            allGroceries.Insert(0, item);
                        }
                        break;
                    case "unnecessary":
                        string unnecenssaryItem = commandArray[1];
                        if (allGroceries.Contains(unnecenssaryItem))
                        {
                            allGroceries.Remove(unnecenssaryItem);
                        }
                        break;
                    case "correct":
                        string oldItem = commandArray[1];
                        string newItem = commandArray[2];
                        if (allGroceries.Contains(oldItem))
                        {
                            int index = allGroceries.IndexOf(oldItem);
                            allGroceries.Insert(index, newItem);
                            allGroceries.Remove(oldItem);
                        }
                        break;
                    case "rearrange":
                        string rearrangeItem = commandArray[1];
                        if (allGroceries.Contains(rearrangeItem))
                        {
                            allGroceries.Remove(rearrangeItem);
                            allGroceries.Add(rearrangeItem);
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", allGroceries));
        }
    }
}
