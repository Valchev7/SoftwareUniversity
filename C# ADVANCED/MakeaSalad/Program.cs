namespace _02._Make_a_Salad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class MakeSalad
    {
        static void Main(string[] args)
        {
            Queue<string> vegitables = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            Stack<int> saladsCalories = new Stack<int>(Console.ReadLine()
                                         .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse));
            int tomatoCalories = 80;
            int carrotCalories = 136;
            int lettuceCalories = 109;
            int potatoCalories = 215;



            while (vegitables.Count > 0 && saladsCalories.Count > 0)
            {
                int currentSaladCalories = saladsCalories.Peek();
                string currentVegitable = vegitables.Peek();
                int calories = 0;

                while (currentSaladCalories > 0)
                {
                    switch (currentVegitable)
                    {
                        case "tomato":
                            calories = tomatoCalories;
                            break;
                        case "carrot":
                            calories = carrotCalories;
                            break;
                        case "lettuce":
                            calories = lettuceCalories;
                            break;
                        case "potato":
                            calories = potatoCalories;
                            break;
                    }
                    //112 calories tomato = 80
                    if (currentSaladCalories - calories > 0)
                    {
                        currentSaladCalories -= calories;
                        vegitables.Dequeue();
                        if (vegitables.Count == 0)
                        {
                            int result = saladsCalories.Pop();
                            Console.Write(result + " ");
                            break;
                        }
                        currentVegitable = vegitables.Peek();
                    }
                    //32 callories left potatto
                    else
                    {
                        vegitables.Dequeue();
                        int result = saladsCalories.Pop();
                        Console.Write(result + " ");
                        break;
                    }
                }

            }
            Console.WriteLine();
            foreach (var item in saladsCalories)
            {
                Console.Write(item + " ");
            }
            foreach (var item in vegitables)
            {
                Console.Write(item + " ");
            }
        }
    }
}