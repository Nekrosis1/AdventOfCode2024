namespace AdventOfCode2024.Day1
{
	public class Day1Input
	{
		public List<int> list1 = new();
		public List<int> list2 = new();

		public void CreateLists()
		{
			string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "inputs", "input1.txt");

			string input = File.ReadAllText(filePath);

			string[] lines = input.Split(["\r\n"], StringSplitOptions.RemoveEmptyEntries);

			foreach (string line in lines)
			{
				string[] parts = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
				if (parts.Length >= 2)
				{
					list1.Add(int.Parse(parts[0]));
					list2.Add(int.Parse(parts[1]));
				}

			};
			list1.Sort();
			list2.Sort();
		}
	}
}





