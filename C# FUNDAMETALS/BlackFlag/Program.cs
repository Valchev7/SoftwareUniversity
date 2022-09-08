using System;

namespace _05._Suitcases_Load
{
    class Program
    {
        static void Main(string[] args)
        {
            double luggageCapacity = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            double luggageVolume = 0.0;
            double count = 0;

            while (command != "End")
            {
                luggageVolume = double.Parse(command);
                if ((count + 1) % 3 == 0)
                {
                    luggageVolume *= 1.1;

                }
                if (luggageCapacity < luggageVolume)
                {
                    Console.WriteLine("No more space!");
                    break;
                }
                luggageCapacity -= luggageVolume;

                command = Console.ReadLine();
                count++;
            }
            if (command == "End")
            {
                Console.WriteLine("Congratulations! All suitcases are loaded!");
            }
            Console.WriteLine($"Statistic: {count} suitcases loaded.");
        }
    }
}