using System;

namespace CoockingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetGiven = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double priceOfPackageFlour = double.Parse(Console.ReadLine());
            double priceOfSingleEgg = double.Parse(Console.ReadLine());
            double priceOfSingleApron = double.Parse(Console.ReadLine());

            double aprons = priceOfSingleApron * Math.Ceiling(studentsCount * 1.20);
            double FlourCount = 0;
            FlourCount = studentsCount;
            double FreeFlour = 0;
            if (FlourCount % 5 == 0)
            {
                FreeFlour += 1;
            }
            double budgetNeeded = aprons + 10 * priceOfSingleEgg * studentsCount + ;
            if (budgetNeeded <= budgetGiven)
            {
                Console.WriteLine($"Items purchased for {budgetNeeded:f2}$.");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(budgetNeeded - budgetGiven)}$ more needed.");
            }
        }
    }
}