using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweet_Dessert
{
    class Program
    {
        static void Main()
        {
            decimal cash = decimal.Parse(Console.ReadLine());
            int numberOfGuests = int.Parse(Console.ReadLine());
            decimal priceBananasUnit = decimal.Parse(Console.ReadLine());
            decimal priceEggsUnit = decimal.Parse(Console.ReadLine());
            decimal priceBerriesKilo = decimal.Parse(Console.ReadLine());

            decimal sets = Math.Ceiling((decimal)numberOfGuests / 6m);

            decimal oneSetPrice = (2m * priceBananasUnit) + (4m * priceEggsUnit) + (0.20m * priceBerriesKilo);

            decimal allPriceOfProducts = sets * oneSetPrice;

            if (allPriceOfProducts <= cash)
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:F2}lv.", allPriceOfProducts);
            }
            else
            {
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0;F2}lv more.", (allPriceOfProducts - cash));
            }
        }
    }
}