using AdventOfCode2024.Day1;
using AdventOfCode2024.Day2;
using AdventOfCode2024.Day3;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AdventOfCode2024
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// _ = Day1Logic.CalculateDifference();
			// _ = Day1Logic.CalculateSimilarity();
			//Day2Input day2Input= new();
			//day2Input.CreateLists();
			// int safeCount = Day2Logic.SafeCount();
			// Console.WriteLine(safeCount);
			// int mulSum = Day3Logic.FindMul();
			int mulSum = Day3Logic.FindConditionalMul();
			Console.WriteLine($"I think the result might be {mulSum}");
		}
	}
}
