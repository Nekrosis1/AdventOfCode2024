using System.Collections;

namespace AdventOfCode2024.Day2
{
	public class Day2Logic
	{
		public int safeCount()
		{
			int safeCount = 0;
			Day2Input day2Input = new();
			List<List<int>> reports = day2Input.CreateLists();
			foreach (List<int> report in reports){
				bool isSafe = checkReport(report);
				safeCount = isSafe ? safeCount ++ : safeCount;
			}
		}

		public bool checkReport(List<int> report){
			for (int i = 0; i < report.Count; i++)
			{
				if ()
			}
			if(report[0] == report[1]){
				return false;
			}
			else if (report[0] > report[1])
			{
				
			}
			else{

			}
		}
	}
}