using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverATWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            int rowsBeaver = 0;
            int colsBeaver = 0;
            int woodBranchCount = 0;
            List<char> woodBranchSymbols = new List<char>();

            for (int rows = 0; rows < n; rows++)
            {
                string[] rowsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int cols = 0; cols < rowsInput.Length; cols++)
                {
                    matrix[rows, cols] = rowsInput[cols];
                    char letter = char.Parse(rowsInput[cols]);
                    if (rowsInput[cols] == "B")
                    {
                        rowsBeaver = rows;
                        colsBeaver = cols;
                    }
                    else if (char.IsLower(letter))
                    {
                        woodBranchCount++;
                    }
                }
            }

            int totalWoodBrunchesCount = woodBranchCount;

            string commands = Console.ReadLine();
            while (commands != "end")
            {
                if (woodBranchCount == 0)
                {
                    break;
                }
                if (commands == "up")
                {
                    if (IsInRange(matrix, rowsBeaver - 1, colsBeaver))
                    {
                        rowsBeaver -= 1;
                        char letter = char.Parse(matrix[rowsBeaver, colsBeaver]);
                        if (char.IsLower(letter))
                        {
                            woodBranchSymbols.Add(letter);
                            woodBranchCount--;
                            matrix[rowsBeaver, colsBeaver] = "B";
                            matrix[rowsBeaver + 1, colsBeaver] = "-";
                        }
                        else if (matrix[rowsBeaver, colsBeaver] == "F")
                        {
                            if (rowsBeaver > 0)
                            {
                                matrix[0, colsBeaver] = "B";
                                matrix[rowsBeaver + 1, colsBeaver] = "-";
                                matrix[rowsBeaver, colsBeaver] = "-";
                                rowsBeaver = 0;
                            }
                            else
                            {
                                char letter1 = char.Parse(matrix[matrix.GetLength(0) - 1, colsBeaver]);
                                matrix[matrix.GetLength(0) - 1, colsBeaver] = "B";
                                matrix[rowsBeaver + 1, colsBeaver] = "-";
                                matrix[rowsBeaver, colsBeaver] = "-";
                                rowsBeaver = matrix.GetLength(0) - 1;
                                if (char.IsLower(letter1))
                                {
                                    woodBranchSymbols.Add(letter1);
                                }
                            }
                        }
                        else
                        {
                            matrix[rowsBeaver, colsBeaver] = "B";
                            matrix[rowsBeaver + 1, colsBeaver] = "-";
                        }
                    }
                    else
                    {
                        if (woodBranchSymbols.Count > 0)
                        {
                            woodBranchSymbols.RemoveAt(woodBranchSymbols.Count - 1);
                        }
                    }
                }
                else if (commands == "down")
                {
                    if (IsInRange(matrix, rowsBeaver + 1, colsBeaver))
                    {
                        rowsBeaver += 1;
                        char letter = char.Parse(matrix[rowsBeaver, colsBeaver]);
                        if (char.IsLower(letter))
                        {
                            woodBranchSymbols.Add(letter);
                            woodBranchCount--;
                            matrix[rowsBeaver, colsBeaver] = "B";
                            matrix[rowsBeaver - 1, colsBeaver] = "-";
                        }
                        else if (matrix[rowsBeaver, colsBeaver] == "F")
                        {
                            if (rowsBeaver < matrix.GetLength(0))
                            {
                                matrix[matrix.GetLength(0) - 1, colsBeaver] = "B";
                                matrix[rowsBeaver - 1, colsBeaver] = "-";
                                matrix[rowsBeaver, colsBeaver] = "-";
                                rowsBeaver = matrix.GetLength(0) - 1;
                            }
                            else
                            {
                                char letter1 = char.Parse(matrix[0, colsBeaver]);
                                matrix[0, colsBeaver] = "B";
                                matrix[rowsBeaver - 1, colsBeaver] = "-";
                                matrix[rowsBeaver, colsBeaver] = "-";
                                rowsBeaver = 0;
                                if (char.IsLower(letter1))
                                {
                                    woodBranchSymbols.Add(letter1);
                                }
                            }
                        }
                        else
                        {
                            matrix[rowsBeaver, colsBeaver] = "B";
                            matrix[rowsBeaver - 1, colsBeaver] = "-";
                        }
                    }
                    else
                    {
                        if (woodBranchSymbols.Count > 0)
                        {
                            woodBranchSymbols.RemoveAt(woodBranchSymbols.Count - 1);
                        }
                    }
                }
                else if (commands == "left")
                {
                    if (IsInRange(matrix, rowsBeaver, colsBeaver - 1))
                    {
                        colsBeaver -= 1;
                        char letter = char.Parse(matrix[rowsBeaver, colsBeaver]);
                        if (char.IsLower(letter))
                        {
                            woodBranchSymbols.Add(letter);
                            woodBranchCount--;
                            matrix[rowsBeaver, colsBeaver] = "B";
                            matrix[rowsBeaver, colsBeaver + 1] = "-";
                        }
                        else if (matrix[rowsBeaver, colsBeaver] == "F")
                        {
                            if (colsBeaver > 0)
                            {
                                matrix[rowsBeaver, 0] = "B";
                                matrix[rowsBeaver, colsBeaver + 1] = "-";
                                matrix[rowsBeaver, colsBeaver] = "-";
                                colsBeaver = 0;
                            }
                            else
                            {
                                char letter1 = char.Parse(matrix[rowsBeaver, matrix.GetLength(1) - 1]);
                                matrix[rowsBeaver, matrix.GetLength(1) - 1] = "B";
                                matrix[rowsBeaver, colsBeaver + 1] = "-";
                                matrix[rowsBeaver, colsBeaver] = "-";
                                colsBeaver = matrix.GetLength(1) - 1;
                                if (char.IsLower(letter1))
                                {
                                    woodBranchSymbols.Add(letter1);
                                }
                            }
                        }
                        else
                        {
                            matrix[rowsBeaver, colsBeaver] = "B";
                            matrix[rowsBeaver, colsBeaver + 1] = "-";
                        }
                    }
                    else
                    {
                        if (woodBranchSymbols.Count > 0)
                        {
                            woodBranchSymbols.RemoveAt(woodBranchSymbols.Count - 1);
                        }
                    }
                }
                else if (commands == "right")
                {
                    if (IsInRange(matrix, rowsBeaver, colsBeaver + 1))
                    {
                        colsBeaver += 1;
                        char letter = char.Parse(matrix[rowsBeaver, colsBeaver]);
                        if (char.IsLower(letter))
                        {
                            woodBranchSymbols.Add(letter);
                            woodBranchCount--;
                            matrix[rowsBeaver, colsBeaver] = "B";
                            matrix[rowsBeaver, colsBeaver - 1] = "-";
                        }
                        else if (matrix[rowsBeaver, colsBeaver] == "F")
                        {
                            if (rowsBeaver < matrix.GetLength(1))
                            {
                                matrix[rowsBeaver, matrix.GetLength(1) - 1] = "B";
                                matrix[rowsBeaver, colsBeaver - 1] = "-";
                                matrix[rowsBeaver, colsBeaver] = "-";
                                colsBeaver = matrix.GetLength(1) - 1;
                            }
                            else
                            {
                                char letter1 = char.Parse(matrix[rowsBeaver, 0]);
                                matrix[rowsBeaver, 0] = "B";
                                matrix[rowsBeaver, colsBeaver - 1] = "-";
                                matrix[rowsBeaver, colsBeaver] = "-";
                                colsBeaver = 0;
                                if (char.IsLower(letter1))
                                {
                                    woodBranchSymbols.Add(letter1);
                                }
                            }
                        }
                        else
                        {
                            matrix[rowsBeaver, colsBeaver] = "B";
                            matrix[rowsBeaver, colsBeaver - 1] = "-";
                        }
                    }
                    else
                    {
                        if (woodBranchSymbols.Count > 0)
                        {
                            woodBranchSymbols.RemoveAt(woodBranchSymbols.Count - 1);
                        }
                    }
                }

                commands = Console.ReadLine();
            }

            if (woodBranchCount == 0)
            {
                Console.Write($"The Beaver successfully collect {woodBranchSymbols.Count} wood branches: ");
                Console.WriteLine($"{string.Join(", ", woodBranchSymbols)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woodBranchCount} branches left.");
            }
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    Console.Write($"{matrix[rows, cols]} ");
                }
                Console.WriteLine();
            }
        }

        public static bool IsInRange(string[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

    }
}