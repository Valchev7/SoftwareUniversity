using System;

namespace Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string input = string.Empty;

            int rountCounter = 0;

            while ((input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);

                if (energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {rountCounter} won battles and {energy} energy");
                    return;
                }

                rountCounter++;
                energy -= distance;

                if (rountCounter % 3 == 0)
                {
                    energy += rountCounter;
                }
            }

            Console.WriteLine($"Won battles: {rountCounter}. Energy left: {energy}");
        }
    }
}