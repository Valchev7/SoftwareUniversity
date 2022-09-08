namespace ExamPreparetionOldExam24._02._2019
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class ClubParty
    {
        public static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();

            Stack<string> elements = new Stack<string>(input);
            Queue<string> halls = new Queue<string>();
            List<int> allGroups = new List<int>();
            int curentCapacity = 0;

            while (elements.Count > 0)
            {
                //input 1 20 b 20 20 a
                string currentElement = elements.Pop();

                bool IsNumber = int.TryParse(currentElement, out int parsedNumber);

                if (!IsNumber)
                {
                    halls.Enqueue(currentElement);
                }
                else
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }
                    //output a -> 20, 20, 20
                    if (curentCapacity + parsedNumber > maxCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", allGroups)}");
                        allGroups.Clear();
                        curentCapacity = 0;
                    }
                    if (halls.Count > 0)
                    {
                        allGroups.Add(parsedNumber);
                        curentCapacity += parsedNumber;
                    }

                }
            }
        }
    }
}