using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day3
{
	public class Day3Input
	{
		public string GetDay3Input()
		{
			string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inputs", "input3.txt");
			string input = File.ReadAllText(filePath);
			return input;
		}
	}
}

