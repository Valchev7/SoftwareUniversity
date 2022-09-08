using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var water = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var flour = Console.ReadLine()
               .Split(' ')
               .ToArray();

            //waterQueue
            Queue<double> waterQue = new Queue<double>();
            foreach (var item in water)
            {
                waterQue.Enqueue(double.Parse(item));
            }
            //water
            Stack<double> flourStack = new Stack<double>();
            foreach (var item in flour)
            {
                flourStack.Push(double.Parse(item));
            }

            Dictionary<string, int> collection = new Dictionary<string, int>();
            collection.Add("Muffin", 0);
            collection.Add("Croissant", 0);
            collection.Add("Baguette", 0);
            collection.Add("Bagel", 0);

            for (int i = 0; i < water.Length; i++)
            {
                var curWater = waterQue.Dequeue();
                var curFlour = flourStack.Pop();

                var combine = curWater + curFlour;

                var bakery = (curWater * 100) / combine;
                switch (bakery)
                {
                    case 40:
                        collection["Muffin"]++;
                        break;
                    case 30:
                        collection["Baguette"]++;
                        break;
                    case 20:
                        collection["Bagel"]++;
                        break;
                    case 50:
                        collection["Croissant"]++;
                        break;
                    default:
                        var flourLeft = curFlour - curWater;
                        flourStack.Push(flourLeft);
                        collection["Croissant"]++;
                        break;
                }
            }
            foreach (var product in collection.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (product.Value > 0)
                {
                    Console.WriteLine(product.Key + ": " + product.Value);
                }
            }
            if (waterQue.Count == 0)
            {
                Console.WriteLine("Water left: None");

            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", waterQue)}");

            }
            if (flourStack.Count == 0)
            {
                Console.WriteLine("Flour left: None");

            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flourStack)}");
            }
        }
    }
}