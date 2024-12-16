using AdventOfCode2024.Day1;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AdventOfCode2024
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int test = Days.Day1.CompareLists();
			Console.WriteLine($"difference: {test}");
		}
	}
}
