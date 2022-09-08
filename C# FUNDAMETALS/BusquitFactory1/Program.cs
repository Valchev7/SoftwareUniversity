using System;

namespace _01.TheBiscuitFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int numBiscuitsPerDay = int.Parse(Console.ReadLine());
            int countWorkers = int.Parse(Console.ReadLine());
            int numBiscuitsFor30Days = int.Parse(Console.ReadLine());

            int currentProduction = countWorkers * numBiscuitsPerDay;

            double productionEveryTirdDay = currentProduction * 0.75;

            double total = currentProduction * 20 + productionEveryTirdDay * 10;

            double diff = 0;

            Console.WriteLine($"You have produced {total} biscuits for the past month.");

            if (total > numBiscuitsFor30Days)
            {
                diff = total - numBiscuitsFor30Days;

                double percentage = diff / numBiscuitsFor30Days * 100;

                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                diff = numBiscuitsFor30Days - total;

                double percentage = diff / numBiscuitsFor30Days * 100;

                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }
        }
    }
}