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
				bool dampened = false;
				//Console.WriteLine($"Checking List: {string.Join(", ", report)}");
				(bool, List<int>) result = CheckReport(report);
				if (!result.Item1)
				{
					dampened = true;
					(bool, List<int>) result2 = CheckReport(result.Item2);
					if (!result2.Item1)
					{
						continue;
					}
					Console.WriteLine($"Result: {result.Item2}");
					safeCount++;
				}
				else
				{
					Console.WriteLine($"Result: {result.Item1}");
					safeCount++;
				}
			}
			return safeCount;
		}

		// dont judge my pyramids
		public static (bool, List<int>) CheckReport(List<int> report)
		{
			if (report[0] == report[1])
			{
				//Console.WriteLine("First two entries are equal, are you even trying?");
				report.RemoveAt(1);
				return (false, report);
			}
			else if (report[0] > report[1])
			{
				// if i need to remove the very first report to succeed, my shit fails,
				// I need a special case checking report[0] and report[1] , and then reports [0] and [2]
				// this seems like an idiotic solution.
				//Console.WriteLine("Seems like descending list");
				for (int i = 1; i < report.Count; i++)
				{
					if ((report[i - 1] - report[i]) < 1 || (report[i - 1] - report[i]) > 3)
					{
						report.RemoveAt(i);
						return (false, report);
					}
				}
			}
			else
			{
				//Console.WriteLine("Seems like ascending list");
				for (int i = 1; i < report.Count; i++)
				{
					if ((report[i] - report[i - 1]) < 1 || (report[i] - report[i - 1]) > 3)
					{
						report.RemoveAt(i);
						return (false, report);

					}
				}
			}
			return (true, report);
		}
	}
}


// Legacy

//public static bool CheckReport(List<int> report)
//{
//	bool dampened = false;
//	if (report[0] == report[1])
//	{
//		//Console.WriteLine("First two entries are equal, are you even trying?");
//		dampened = true;
//		report.RemoveAt(1);

//		//return false;
//	}
//	if (report[0] > report[1])
//	{
//		//Console.WriteLine("Seems like descending list");
//		for (int i = 1; i < report.Count; i++)
//		{
//			if ((report[i - 1] - report[i]) < 1 || (report[i - 1] - report[i]) > 3)
//			{
//				if (dampened == false)
//				{
//					dampened = true;
//					report.RemoveAt(i);
//					// when the first level fails, -2 creates a negative if report[i-1]is requested
//					if (i > 2)
//					{
//						i -= 2;
//					}
//					else
//					{
//						i--;
//					}
//					continue;
//				}
//				return false;
//			}
//		}
//	}
//	else
//	{
//		//Console.WriteLine("Seems like ascending list");
//		for (int i = 1; i < report.Count; i++)
//		{
//			if ((report[i] - report[i - 1]) < 1 || (report[i] - report[i - 1]) > 3)
//			{
//				if (dampened == false)
//				{
//					dampened = true;
//					report.RemoveAt(i);
//					// when the first level fails, -2 creates a negative if report[i-1]is requested
//					if (i > 2)
//					{
//						i -= 2;
//					}
//					else
//					{
//						i--;
//					}
//					continue;
//				}
//				return false;
//			}
//		}
//	}
//	return true;
//}