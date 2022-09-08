using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            Dictionary<string, int> namesAndAmounts = new Dictionary<string, int>();
            Dictionary<string, int> presentsAndTotalAmount = new Dictionary<string, int>();
            while ((text = Console.ReadLine()) != "END")
            {

                string[] childrens = text.Split("->").ToArray();
                if (childrens[0] == "Remove")
                {

                    namesAndAmounts.Remove(childrens[1]);
                }
                else
                {
                    string name = childrens[0];
                    string present = childrens[1];
                    int amount = int.Parse(childrens[2]);
                    if (!namesAndAmounts.ContainsKey(name) && !presentsAndTotalAmount.ContainsKey(present))
                    {
                        namesAndAmounts.Add(name, amount);
                        presentsAndTotalAmount.Add(present, amount);

                    }
                    else if (namesAndAmounts.ContainsKey(name))
                    {
                        namesAndAmounts[name] += amount;
                    }
                    else if (presentsAndTotalAmount.ContainsKey(present))
                    {
                        presentsAndTotalAmount[present] += amount;
                    }
                }
            }

            Console.WriteLine($"Children:");
            foreach (var kvp in namesAndAmounts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
            Console.WriteLine($"Presents:");
            foreach (var kvp in presentsAndTotalAmount)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }


        }
    }
}