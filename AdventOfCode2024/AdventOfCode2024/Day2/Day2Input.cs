using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace AdventOfCode2024.Day2
{
	public class Day2Input
	{
		List<List<int>> reports = new();
		public List<List<int>> CreateLists()
		{
			string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inputs", "input2test.txt");

			string input = File.ReadAllText(filePath);

			string[] lines = input.Split(["\r\n"], StringSplitOptions.RemoveEmptyEntries);

			foreach (string line in lines)
			{
				string[] parts = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
				List<int> report = parts.Select(int.Parse).ToList();
				reports.Add(report);

			};

			Console.WriteLine(reports.ToString());
			return;
		}
	}
}