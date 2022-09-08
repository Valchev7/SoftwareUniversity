using System;
using System.Linq;

namespace hunting_games
{
    class Program
    {
        static void Main(string[] args)
        {
            double daysOfAdventure = double.Parse(Console.ReadLine());
            double numberOfPlayers = double.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDay = double.Parse(Console.ReadLine());
            double foodPerDay = double.Parse(Console.ReadLine());

            double energyEveryDay = groupEnergy;
            double count = 0;

            while (daysOfAdventure > 0)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                double totalWater = daysOfAdventure * numberOfPlayers * waterPerDay;
                double totalFood = daysOfAdventure * numberOfPlayers * foodPerDay;

                energyEveryDay = energyEveryDay - energyLoss;
                count++;

                if (count % 2 == 0)
                {
                    energyEveryDay = energyEveryDay + energyEveryDay * 0.05;
                    totalWater = totalWater - totalWater * 0.30;
                }
                if (count % 3 == 0)
                {
                    energyEveryDay = energyEveryDay + energyEveryDay * 0.10;
                    totalFood = totalFood - totalFood / numberOfPlayers;
                }
                daysOfAdventure--;

                if (energyEveryDay < 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water");
                }


            }
            if (energyEveryDay > 0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energyEveryDay:f2} energy!");
            }

        }
    }
}