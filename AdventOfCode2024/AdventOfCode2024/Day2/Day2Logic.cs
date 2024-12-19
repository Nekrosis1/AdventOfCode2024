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
					Console.WriteLine($"Damped Result: {result2.Item1}");
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
				bool firstIsFail = false;
			if (report[0] == report[1])
			{
				//Console.WriteLine("First two entries are equal, are you even trying?");
				report.RemoveAt(1);
				return (false, report);
			}
			else if (report[0] > report[1])
			{
				// if I need to remove the very first report to succeed, my shit fails,
				// I need a special case checking report[0] and report[1] , and then reports [0] and [2]
				// this seems like an idiotic solution.
				if ((report[0] - report[1]) < 1 || (report[0] - report[1]) > 3)
				{
					if ((report[0] - report[2]) < 1 || (report[0] - report[2]) > 3)
					{
						if (firstIsFail)
						{
							// this is absolutely retarded.
							return (false, [2,2,2,2]);
						}
						firstIsFail = true;
						report.RemoveAt(0);
						// CheckReport(report);
					}
				}
				//Console.WriteLine("Seems like descending list");
				for (int i = 1; i < report.Count; i++)
				{
					if ((report[i - 1] - report[i]) < 1 || (report[i - 1] - report[i]) > 3)
					{
						if(firstIsFail)
						{
							return (false, [2,2,2,2]);
						}
						report.RemoveAt(i);
						return (false, report);
					}
				}
			}
			else
			{
				if ((report[1] - report[0]) < 1 || (report[1] - report[0]) > 3)
				{
					if ((report[2] - report[0]) < 1 || (report[2] - report[0]) > 3)
					{
						if (firstIsFail)
						{
							// this is absolutely retarded.
							return (false, [2,2,2,2]);
						}
						firstIsFail = true;
						report.RemoveAt(0);
						// CheckReport(report);
					}
				}
				//Console.WriteLine("Seems like ascending list");
				for (int i = 1; i < report.Count; i++)
				{
					if ((report[i] - report[i - 1]) < 1 || (report[i] - report[i - 1]) > 3)
					{
						if(firstIsFail)
						{
							return (false, [2,2,2,2]);
						}
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