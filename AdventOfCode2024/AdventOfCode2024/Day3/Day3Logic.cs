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
		public static int FindMul(string input)
		{
			Day3Input day3Input = new();
			List<int> products = [];
			// input = day3Input.GetDay3Input();
			string pattern = @"mul\([0-9]{1,3},[0-9]{1,3}\)";
			MatchCollection matches = Regex.Matches(input, pattern);
			// Console.WriteLine(string.Join(", ", matches));
			foreach (Match match in matches)
			{
				// Fancy ass range operator, because I'm pretentious
				string numberStr = match.Value[4..^1];
				// Console.WriteLine(numberStr);
				string[] factors = numberStr.Split(',');
				List<int> numbers = [];
				foreach (string numberString in factors)
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

			string pattern = @"do\(\)|don't\(\)";
			// Find all matches do() / don't()
			MatchCollection matches = Regex.Matches(input, pattern);

			int prevIndex = 0;
			for (int i = 0; i < matches.Count(); i++)
			{
				// get last found do() / don't()
				string prevMatchType;
				if (i == 0)
				{
					prevMatchType = "do()";
				}
				else
				{
					// yes this is a dumb way to do this
					prevMatchType = matches[i - 1].Value;

				}
				// do FindMul if last match is do() or is start of string
				if (prevMatchType == "do()")
				{
					Console.WriteLine("found do(), searching");
					Console.WriteLine(input[prevIndex..matches[i].Index]);
					products.Add(FindMul(input[prevIndex..matches[i].Index]));
				}
				else
				{
					Console.WriteLine("found don't(), ignoring");
					Console.WriteLine(input[prevIndex..matches[i].Index]);
				}
				prevIndex = matches[i].Index + matches[i].Length;
			}
			// do findmul on last section
			if (matches[matches.Count - 1].Value == "do()")
			{
				Console.WriteLine("found do(), searching");
				Console.WriteLine(input[matches[matches.Count - 1].Index..input.Length]);
				products.Add(FindMul(input[matches[matches.Count - 1].Index..input.Length]));

			}
			return products.Sum();
		}
	}

}



