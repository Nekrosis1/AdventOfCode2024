using AdventOfCode2024.Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Days
{
	public class Day1
	{
		public static List<int> SortList(List<int> list){
			list.Sort();
			return list;
		}
		public static int CompareLists()
		{
			int totalDifference = 0;
		InputFormat day1Input = new InputFormat();
			day1Input.CreateLists();
            for (int i = 0; i < day1Input.list1.Count; i++)
            {
				int num1 = day1Input.list1[i];
				int num2 = day1Input.list2[i];
				int difference = Math.Abs(num1 - num2);
				totalDifference += difference;
            }
			return totalDifference;
		}
	}
}
