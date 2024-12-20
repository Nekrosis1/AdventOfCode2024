using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace AdventOfCode2024.Day3
{
    public class Day3Logic
    {
        public static int FindMul()
        {
            Day3Input day3Input = new();
            List<int> products = [];
            string input = day3Input.GetDay3Input();
            string pattern = @"mul\([0-9]{1,3},[0-9]{1,3}\)";
            MatchCollection matches = Regex.Matches(input, pattern);
            // Console.WriteLine(string.Join(", ", matches));
            foreach (Match match in matches)
            {
                // Fancy ass range operator, because I'm pretentious
                string numberStr = match.Value[4..^1];
                // Console.WriteLine(numberStr);
                string[] test = numberStr.Split(',');
                List<int> numbers = [];
                foreach (string numberString in test)
                {
                    bool success = int.TryParse(numberString, out int number);
                    if (!success)
                    {
                        Console.WriteLine("I fucked up at TryParse");
                        return 0;
                    }
                    numbers.Add(number);
                }
                // Console.WriteLine($"numbers are {numbers[0]} and {numbers[1]}");
                int product = numbers[0] * numbers[1];
                products.Add(product);
            }
            return products.Sum();
        }

        public static int FindConditionalMul()
        {
            Day3Input day3Input = new();
            List<int> products = [];
            string input = day3Input.GetDay3Input();

            // search for do's and dont's
            
            // split at do's and dont's
            // discard dont's
            



            string pattern = @"mul\([0-9]{1,3},[0-9]{1,3}\)";
            MatchCollection matches = Regex.Matches(input, pattern);
            Console.WriteLine(string.Join(", ", matches));
            foreach (Match match in matches)
            {
                // Why the fuck is this (start, length) not (start, end)?!
                string numberStr = match.Value.Substring(4, match.Value.Length - 5);
                Console.WriteLine(numberStr);
                string[] test = numberStr.Split(',');
                List<int> numbers = [];
                foreach (string numberString in test)
                {
                    bool success = int.TryParse(numberString, out int number);
                    if (!success)
                    {
                        Console.WriteLine("I fucked up at TryParse");
                        return 0;
                    }
                    numbers.Add(number);
                }
                // Console.WriteLine($"numbers are {numbers[0]} and {numbers[1]}");
                int product = numbers[0] * numbers[1];
                products.Add(product);
            }
            return products.Sum();
        }
    }



}