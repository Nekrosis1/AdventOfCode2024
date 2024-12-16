namespace AdventOfCode2024.Day1
{
	public class Day1Logic
	{
		public static int CalculateDifference()
		{
			int totalDifference = 0;
			Day1Input day1Input = new();
			day1Input.CreateLists();
			for (int i = 0; i < day1Input.list1.Count; i++)
			{
				int num1 = day1Input.list1[i];
				int num2 = day1Input.list2[i];
				int difference = Math.Abs(num1 - num2);
				totalDifference += difference;
			}
			Console.WriteLine($"Difference: {totalDifference}");
			return totalDifference;
		}

		public static int CalculateSimilarity()
		{
			int totalSimilarity = 0;
			Day1Input day1Input = new();
			day1Input.CreateLists();
			foreach (int element in day1Input.list1)
			{
				int matchCount = day1Input.list2.Where(e => e == element).Count();
				totalSimilarity += element * matchCount;
			}
			Console.WriteLine($"Similarity: {totalSimilarity}");
			return totalSimilarity;
		}
	}
}
