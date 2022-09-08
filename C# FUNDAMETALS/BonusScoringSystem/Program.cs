using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main()
        {
            var studentCount = double.Parse(Console.ReadLine());
            var lecturesCount = double.Parse(Console.ReadLine());

            var courseBonus = double.Parse(Console.ReadLine());

            var studentWithMaxBonus = int.MinValue;
            int maxAtt = int.MinValue;


            if (studentCount == 0 || lecturesCount == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }

            for (int i = 0; i < studentCount; i++)
            {
                int attendance = int.Parse(Console.ReadLine());

                double temp = Math.Ceiling(attendance / lecturesCount * (5 + courseBonus));

                if (temp > studentWithMaxBonus)
                {
                    studentWithMaxBonus = (int)temp;
                    maxAtt = attendance;
                }
            }

            Console.WriteLine($"Max Bonus: {studentWithMaxBonus}.");
            Console.WriteLine($"The student has attended {maxAtt} lectures.");


        }
    }
}