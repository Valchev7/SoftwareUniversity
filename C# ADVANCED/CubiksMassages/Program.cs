﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03_CubiksMessages
{
    public class CubiksMessages
    {
        public static void Main()
        {
            //Messages1();
            Messages2();
        }

        private static void Messages2()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Over!") break;

                var len = int.Parse(Console.ReadLine());
                var pattern = @"^(?<m>(?<d1>[0-9]+?)(?<msg>[a-zA-Z]{" + len + @"})(?<d2>[^a-zA-Z]*?))$";
                var regex = new Regex(pattern);
                var match = regex.Match(input);

                if (match.Success)
                {
                    var msg = match.Groups["msg"].Value;
                    var leadingDigits = match.Groups["d1"].Value;
                    var trailingChars = match.Groups["d2"].Value;

                    var indices = new List<int>();
                    indices = GetDigits(indices, leadingDigits);
                    indices = GetDigits(indices, trailingChars);

                    var decryptedMsg = DecriptMsg(msg, indices);
                    if (decryptedMsg != string.Empty)
                    {
                        Console.WriteLine($"{msg} == {decryptedMsg}");
                    }
                }
            }
        }

        private static void Messages1()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Over!") break;

                var length = int.Parse(Console.ReadLine());

                var index = 0;
                // leading pattern: digits only
                var leadingDigits = new StringBuilder();
                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.IsDigit(input[i]))
                    {
                        leadingDigits.Append(input[i]);
                    }
                    else
                    {
                        index = i; break;
                    }
                }

                // msg length: exact length
                if (input.Substring(index).Length < length)
                {
                    continue;
                }

                // msg pattern: letters only
                var msg = input.Substring(index, length);
                if (Regex.IsMatch(msg, "[^a-zA-Z]"))
                {
                    continue;
                }

                // remainder pattern: does not contain any letters
                string remainder = input.Substring(index + length);
                if (Regex.IsMatch(remainder, "[a-zA-Z]"))
                {
                    continue;
                }

                // indices of leading & trailing digits
                var indices = new List<int>();
                indices = GetDigits(indices, leadingDigits.ToString());
                indices = GetDigits(indices, remainder);

                // decrypt msg from indices
                var decryptedMsg = DecriptMsg(msg, indices);
                if (decryptedMsg != string.Empty)
                {
                    Console.WriteLine($"{msg} == {decryptedMsg}");
                }
            }
        }

        private static string DecriptMsg(string msg, List<int> indices)
        {
            var builder = new StringBuilder();
            foreach (var index in indices)
            {
                if (index >= 0 && index < msg.Length)
                {
                    builder.Append(msg[index]);
                }
                else
                {
                    builder.Append(" ");
                }
            }
            return builder.ToString();
        }

        private static List<int> GetDigits(List<int> indices, string text)
        {
            if (text.Length == 0) return indices;

            foreach (var ch in text)
            {
                if (char.IsDigit(ch))
                {
                    indices.Add(int.Parse(ch.ToString()));
                }
            }
            return indices;
        }
    }
}