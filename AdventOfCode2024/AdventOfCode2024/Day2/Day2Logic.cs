using System.Collections;

namespace AdventOfCode2024.Day2
{
	public static class Day2Logic
	{
		public static int SafeCount()
		{
			int safeCount = 0;
			Day2Input day2Input = new();
			List<List<int>> reports = day2Input.CreateLists();
			foreach (List<int> report in reports)
			{
				//Console.WriteLine($"Checking List: {string.Join(", ", report)}");
				bool isSafe = CheckReport(report);
				Console.WriteLine($"Result: {isSafe}");
				safeCount = isSafe ? (safeCount +1) : safeCount;
			}
			return safeCount;
		}
		
		// dont judge my pyramids
		public static bool CheckReport(List<int> report)
		{

			if (report[0] == report[1])
			{
				//Console.WriteLine("First two entries are equal, are you even trying?");
				return false;
			}
			else if (report[0] > report[1])
			{
				//Console.WriteLine("Seems like descending list");
				for (int i = 1; i < report.Count; i++)
				{
					if ((report[i - 1] - report[i]) < 1 || (report[i - 1] - report[i]) > 3)
					{
						return false;
					}
				}
			}
			else
			{
				//Console.WriteLine("Seems like ascending list");
				for (int i = 1; i < report.Count; i++)
				{
					if ((report[i] - report[i - 1]) < 1 || (report[i] - report[i-1]) > 3)
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}