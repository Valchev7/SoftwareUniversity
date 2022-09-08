using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowelsQ = new Queue<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());

            Stack<char> consonantsSt = new Stack<char>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());

            string pear = "pear"; //4
            string flour = "flour"; //5
            string pork = "pork";//4
            string olive = "olive";//5

            int pearLength = 4;
            int flourLength = 5;
            int porkLength = 4;
            int oliveLength = 5;

            int totalWordsFound = 0;
            List<string> listFound = new List<string>();


            while (consonantsSt.Count > 0)
            {

                char currVowel = vowelsQ.Dequeue();
                vowelsQ.Enqueue(currVowel);
                char currConsonant = consonantsSt.Pop();


                if (pear.Contains(currVowel))
                {
                    pear = pear.Replace(currVowel, ' ');
                    pearLength--;
                }

                if (flour.Contains(currVowel))
                {
                    flour = flour.Replace(currVowel, ' ');
                    flourLength--;
                }

                if (pork.Contains(currVowel))
                {
                    pork = pork.Replace(currVowel, ' ');
                    porkLength--;
                }

                if (olive.Contains(currVowel))
                {
                    olive = olive.Replace(currVowel, ' ');
                    oliveLength--;
                }

                if (pear.Contains(currConsonant))
                {
                    pear = pear.Replace(currConsonant, ' ');
                    pearLength--;
                }

                if (flour.Contains(currConsonant))
                {
                    flour = flour.Replace(currConsonant, ' ');
                    flourLength--;
                }

                if (pork.Contains(currConsonant))
                {
                    pork = pork.Replace(currConsonant, ' ');
                    porkLength--;
                }

                if (olive.Contains(currConsonant))
                {
                    olive = olive.Replace(currConsonant, ' ');
                    oliveLength--;
                }
            }

            if (pearLength == 0)
            {
                totalWordsFound++;
                listFound.Add("pear");
            }

            if (flourLength == 0)
            {
                totalWordsFound++;
                listFound.Add("flour");
            }

            if (porkLength == 0)
            {
                totalWordsFound++;
                listFound.Add("pork");
            }

            if (oliveLength == 0)
            {
                totalWordsFound++;
                listFound.Add("olive");
            }

            Console.WriteLine($"Words found: {totalWordsFound}");

            listFound.ForEach(Console.WriteLine);
        }
    }
}