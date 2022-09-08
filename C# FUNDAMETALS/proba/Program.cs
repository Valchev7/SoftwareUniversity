using System;

namespace CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceOfPackageOfFlour = double.Parse(Console.ReadLine());
            double priceOfSingleEgg = double.Parse(Console.ReadLine());
            double priceOfSingleApron = double.Parse(Console.ReadLine());
            
            double numberOfFreePacksFlour = students / 5;
            double educationSetPerStudent = priceOfSingleApron * Math.Ceiling(students * 1.20) + ((priceOfSingleEgg * 10) * students) + priceOfPackageOfFlour * students;
                                    
            double test = 0.0;

            double sumNeeded = 0.0;

            double freePackOfFlour = priceOfPackageOfFlour;

            if (students < 5)
            {
                double usedMoney = educationSetPerStudent;
                if (usedMoney <= budget)
                {
                    Console.WriteLine($"Items purchased for {usedMoney:F2}$.");
                }
                else
                {
                    double moneyNeeded = usedMoney - budget;
                    Console.WriteLine($"{moneyNeeded:F2}$ more needed.");
                }
            }
            else if (students >= 5)
            {
                test = students / 5;
                double numberOfFreeFlour = (int)test * priceOfPackageOfFlour;
                double usedMoney = educationSetPerStudent - numberOfFreeFlour;
                if (usedMoney <= budget)
                {
                    Console.WriteLine($"Items purchased for {usedMoney:F2}$.");
                }
                else
                {
                    double moneyNeeded = usedMoney - budget;
                    Console.WriteLine($"{moneyNeeded:F2}$ more needed.");
                }
            }


        }
    }
}