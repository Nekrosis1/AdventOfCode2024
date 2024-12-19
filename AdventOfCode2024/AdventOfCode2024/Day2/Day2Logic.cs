using System.Collections;
using System.Net;

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
				// bool dampened = false;
				//Console.WriteLine($"Checking List: {string.Join(", ", report)}");
				(bool, List<int>) result = CheckReport2(report);
				if (!result.Item1)
				{
						Console.WriteLine(string.Join(", ", result.Item2));
						Console.WriteLine($"FAIL");
						Console.WriteLine("\n");
						continue;
					}
					Console.WriteLine(string.Join(", ", result.Item2));
					Console.WriteLine($"SUCCESS");
					Console.WriteLine("\n");
					safeCount++;
			}
			return safeCount;
		}

		public static (bool, List<int>) CheckReport2(List<int> report)
		{
			bool damped = false;
			if (report[0] == report[1])
			{
				//Console.WriteLine("First two entries are equal, are you even trying?");
				report.RemoveAt(1);
				damped = true;
			}
			// descending list
			if (report[0] > report[1])
			{
				(bool, List<int>) result = CheckDescending(report);
				// if failed undamped
				if (!result.Item1)
				{
					if (damped)
					{
						// was already damped by report[0]&[1] being eq
						return (false, report);
					}
					(bool, List<int>) isDampedSafe = CheckDescending(result.Item2);
					if (!isDampedSafe.Item1)
					{
						// report got damped and still fails
						return (false, report);
					}
					// descending list success after damping
					return (true, report);
				}
				// descending list success without damping
				return (true, report);
			}
			// ascending list
			else
			{
				(bool, List<int>) result = CheckAscending(report);
				// if failed undamped
				if (!result.Item1)
				{
					if (damped)
					{
						// was already damped by report[0]&[1] being eq
						return (false, report);
					}
					(bool, List<int>) isDampedSafe = CheckAscending(result.Item2);
					if (!isDampedSafe.Item1)
					{
						// report got damped and still fails
						return (false, report);
					}
					// Ascending list success after damping
					return (true, report);
				}
				// Ascending list success without damping
				return (true, report);
			}
		}

		public static (bool, List<int>) CheckDescending(List<int> report)
		{
			for (int i = 0; i < report.Count - 1; i++)
			{
				// if bad
				if ((report[i] - report[i+1]) < 1 || (report[i] - report[i+1]) > 3)
				{
					// report.RemoveAt(i);
					List<int> dampedReport = report;
					dampedReport.RemoveAt(i+1);
					return (false, dampedReport);
				}
			}
			return (true, report);
		}

		public static (bool, List<int>) CheckAscending(List<int> report)
		{
			for (int i = 0; i < report.Count - 1; i++)
			{
				//if bad
				if ((report[i+1] - report[i]) < 1 || (report[i+1] - report[i]) > 3)
				{
					List<int> dampedReport = report;
					dampedReport.RemoveAt(i+1);
					return (false, dampedReport);
				}
			}
			return (true, report);
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
							return (false, [2, 2, 2, 2]);
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
						if (firstIsFail)
						{
							return (false, [2, 2, 2, 2]);
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
							return (false, [2, 2, 2, 2]);
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
						if (firstIsFail)
						{
							return (false, [2, 2, 2, 2]);
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