namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class TheGarden
    {
        static void Main(string[] args)
        {
            int numberRows = int.Parse(Console.ReadLine());
            char[][] vegatebleField = new char[numberRows][];

            Dictionary<char, int> harvestVegitables = new Dictionary<char, int>();
            harvestVegitables['L'] = 0;
            harvestVegitables['P'] = 0;
            harvestVegitables['C'] = 0;

            int harmedVegitables = 0;

            for (int row = 0; row < numberRows; row++)
            {
                //char[] inputVegatables = Console.ReadLine().Split(new char[' '],StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                string[] inputVegatables = Console.ReadLine().Split(' ');
                vegatebleField[row] = new char[inputVegatables.Length];
                for (int cols = 0; cols < vegatebleField[row].Length; cols++)
                {
                    vegatebleField[row][cols] = char.Parse(inputVegatables[cols]);
                }
            }

            string input = Console.ReadLine();

            while (input != "End of Harvest")
            {
                string[] commandLine = input.Split(' ');
                //Harvest 0 2
                if (commandLine[0] == "Harvest")
                {
                    int rowHarvest = int.Parse(commandLine[1]);
                    int colHarvest = int.Parse(commandLine[2]);

                    if (rowHarvest < numberRows && colHarvest < vegatebleField[rowHarvest].Length)
                    {
                        char vegitable = vegatebleField[rowHarvest][colHarvest];

                        if (vegitable == 'L' || vegitable == 'P' || vegitable == 'C')
                        {
                            vegatebleField[rowHarvest][colHarvest] = ' ';

                            harvestVegitables[vegitable]++;
                        }
                    }
                }
                //Mole 2 2 up
                else if (commandLine[0] == "Mole")
                {
                    int rowMole = int.Parse(commandLine[1]);
                    int colMole = int.Parse(commandLine[2]);
                    string direction = commandLine[3];

                    if (rowMole < numberRows && colMole < vegatebleField[rowMole].Length)
                    {
                        if (vegatebleField[rowMole][colMole] != ' ')
                        {
                            vegatebleField[rowMole][colMole] = ' ';
                            harmedVegitables++;
                        }

                        switch (direction)
                        {
                            case "up":
                                for (int i = rowMole; i >= 0; i -= 2)
                                {
                                    if (vegatebleField[i][colMole] != ' ')
                                    {
                                        vegatebleField[i][colMole] = ' ';
                                        harmedVegitables++;
                                    }
                                }
                                break;
                            case "down":
                                for (int i = rowMole; i < numberRows; i += 2)
                                {
                                    if (vegatebleField[i][colMole] != ' ')
                                    {
                                        vegatebleField[i][colMole] = ' ';
                                        harmedVegitables++;
                                    }
                                }
                                break;
                            case "left":
                                for (int i = colMole; i >= 0; i -= 2)
                                {
                                    if (vegatebleField[rowMole][i] != ' ')
                                    {
                                        vegatebleField[rowMole][i] = ' ';
                                        harmedVegitables++;
                                    }
                                }
                                break;
                            case "right":
                                for (int i = colMole; i < vegatebleField[rowMole].Length; i += 2)
                                {
                                    if (vegatebleField[rowMole][i] != ' ')
                                    {
                                        vegatebleField[rowMole][i] = ' ';
                                        harmedVegitables++;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            for (int row = 0; row < numberRows; row++)
            {
                for (int col = 0; col < vegatebleField[row].Length; col++)
                {
                    Console.Write(vegatebleField[row][col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Carrots: {harvestVegitables['C']}");
            Console.WriteLine($"Potatoes: {harvestVegitables['P']}");
            Console.WriteLine($"Lettuce: {harvestVegitables['L']}");
            Console.WriteLine($"Harmed vegetables: {harmedVegitables}");
        }
    }
}