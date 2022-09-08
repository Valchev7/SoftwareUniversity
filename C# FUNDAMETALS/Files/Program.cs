using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication15
{
    class Program
    {
        static void Main(string[] args)
        {
            var finalInfos = new SortedDictionary<string, Dictionary<string, Dictionary<string, Dictionary<long, string>>>>();
            //directory -> filename -> fileend -> filesize
            var final = new Dictionary<string, long>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string read = Console.ReadLine();
                string[] info = read.Split('\\', ';').ToArray();
                string directory = info[0];
                long size = Int64.Parse(info[info.Length - 1]);
                string filenamee = info[info.Length - 2];
                string pattern = @".([^.\\]+)$";
                string filename = Regex.Replace(filenamee, pattern, "");
                string fileend = filenamee.Replace(filename, "");
                string finalInfo = directory + "\\" + filename + fileend;
                finalInfos[finalInfo] = new Dictionary<string, Dictionary<string, Dictionary<long, string>>>();
                finalInfos[finalInfo][filename] = new Dictionary<string, Dictionary<long, string>>();
                finalInfos[finalInfo][filename][fileend] = new Dictionary<long, string>();
                finalInfos[finalInfo][filename][fileend][size] = directory;
            }
            string function = Console.ReadLine();
            string[] funcInfo = function.Split(' ').ToArray();
            string ende = funcInfo[0];
            string end = "." + ende;
            string dir = funcInfo[2];
            foreach (var dvoika in finalInfos)
            {
                foreach (var pair in dvoika.Value)
                {
                    foreach (var item in pair.Value.Where(w => w.Key == end))
                    {
                        foreach (var thing in item.Value.Where(x => x.Value == dir).OrderByDescending(y => y.Key))
                        {
                            string lastanme = pair.Key + item.Key;
                            final[lastanme] = thing.Key;
                        }
                    }
                }
            }
            if (final.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                foreach (var pair in final.OrderByDescending(w => w.Value))
                {
                    Console.WriteLine($"{pair.Key} - {pair.Value} KB");
                }
            }
        }
    }
}