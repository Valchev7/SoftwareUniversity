using System;

namespace Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceWithoutTaxes = 0;
            double totalPrice = 0;
            double taxes = 0;
            while (true)
            {
                string priceOfParts = Console.ReadLine();
                if (priceOfParts == "regular")
                {
                    priceWithoutTaxes = totalPrice;
                    double priceWithTaxes = 1.2 * totalPrice;
                    taxes = priceWithTaxes - totalPrice;
                    totalPrice = 1.2 * totalPrice;
                    if (totalPrice == 0)
                    {
                        Console.WriteLine("Invalid order!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Congratulations you've just bought a new computer!");
                        Console.WriteLine($"Price without taxes: {priceWithoutTaxes:F2}$");
                        Console.WriteLine($"Taxes: {taxes:F2}$");
                        Console.WriteLine("-----------");
                        Console.WriteLine($"Total price: {totalPrice:F2}$");
                        return;
                    }
                }
                if (priceOfParts == "special")
                {
                    priceWithoutTaxes = totalPrice;
                    double priceWithTaxes = 1.2 * totalPrice;
                    taxes = priceWithTaxes - totalPrice;
                    totalPrice = 0.9 * priceWithTaxes;
                    if (totalPrice == 0)
                    {
                        Console.WriteLine("Invalid order!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Congratulations you've just bought a new computer!");
                        Console.WriteLine($"Price without taxes: {priceWithoutTaxes:F2}$");
                        Console.WriteLine($"Taxes: {taxes:F2}$");
                        Console.WriteLine("-----------");
                        Console.WriteLine($"Total price: {totalPrice:F2}$");
                        return;
                    }
                }
                else
                {
                    if (double.Parse(priceOfParts) <= 0)
                    {
                        Console.WriteLine("Invalid price!");
                        continue;
                    }
                }
                totalPrice += double.Parse(priceOfParts);
            }

        }
    }
}