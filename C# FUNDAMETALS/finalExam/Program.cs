using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoffeSupply
{
    class SoftUniCoffeSupply
    {
        static void Main(string[] args)
        {
            string[] delimeters = Console.ReadLine().Split();
            string firstDelimeter = delimeters[0];
            string secondDelimeter = delimeters[1];
            Dictionary<string, ulong> CoffeTypeAndQuantity = new Dictionary<string, ulong>();
            Dictionary<string, string> PersonAndCoffe = new Dictionary<string, string>();
            // Reading information about coffees, types and people who want them
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of info")
                {
                    break;
                }
                if (input.Contains(firstDelimeter))
                {
                    string[] personinfo = input.Split(new[] { firstDelimeter }, StringSplitOptions.None);
                    if (!PersonAndCoffe.ContainsKey(personinfo[0]))
                    {
                        PersonAndCoffe.Add(personinfo[0], personinfo[1]);
                    }
                    else
                    {
                        PersonAndCoffe[personinfo[0]] = personinfo[1];
                    }
                    foreach (var pair in PersonAndCoffe)
                    {
                        if (!CoffeTypeAndQuantity.ContainsKey(pair.Value))
                        {
                            CoffeTypeAndQuantity.Add(pair.Value, 0);
                        }
                    }
                }
                else
                {
                    string[] coffeeinfo = input.Split(new[] { secondDelimeter }, StringSplitOptions.None);
                    if (!CoffeTypeAndQuantity.ContainsKey(coffeeinfo[0]))
                    {
                        CoffeTypeAndQuantity.Add(coffeeinfo[0], ulong.Parse(coffeeinfo[1]));
                    }
                    else
                    {
                        CoffeTypeAndQuantity[coffeeinfo[0]] += ulong.Parse(coffeeinfo[1]);
                    }
                }
            }
            // Reading information about quantity of coffee to be drinked
            while (true)
            {
                string command = Console.ReadLine();
                string[] QuantityWanted = command.Split();
                if (command == "end of week")
                {
                    break;
                }
                string name = QuantityWanted[0];
                ulong quantity = ulong.Parse(QuantityWanted[1]);
                string coffee = PersonAndCoffe[name];
                CoffeTypeAndQuantity[coffee] -= quantity;
            }
            // Sorting the dictionaries
            var SortedCoffees = CoffeTypeAndQuantity.OrderByDescending(x => x.Value).Where(x => x.Value > 0).ToDictionary(x => x.Key.ToString(), x => ulong.Parse(x.Value.ToString()), StringComparer.OrdinalIgnoreCase);
            var SortedLeft = PersonAndCoffe.OrderBy(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key.ToString(), x => x.Value.ToString(), StringComparer.OrdinalIgnoreCase);
            // Printing the results
            foreach (var coffee in CoffeTypeAndQuantity)
            {
                if (coffee.Value == 0)
                {
                    Console.WriteLine($"Out of {coffee.Key}");
                }
            }
            Console.WriteLine("Coffee Left:");
            foreach (var coffee in SortedCoffees)
            {
                Console.WriteLine($"{coffee.Key} {coffee.Value}");
            }
            Console.WriteLine("For:");
            foreach (var pair in SortedLeft)
            {
                if (SortedCoffees.ContainsKey(pair.Value))
                {
                    Console.WriteLine($"{pair.Key} {pair.Value}");
                }
            }
        }
    }
}