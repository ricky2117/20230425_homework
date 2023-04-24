using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace students_info
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Student student = new Student("小明", 23, new Subject("國文", 70), new Subject("英文", 50), new Subject("數學", 50));

			Console.WriteLine(student.Get_information());
			Console.WriteLine(student.TotalScore());
			Console.WriteLine(student.AverageScore());
			Console.WriteLine(student.HighestScore());
			Console.WriteLine(student.LowestScore());

			Console.ReadLine();

		}
		public class Student
		{
			public string Name { get; }
			public int Age { get; }
			public List<Subject> Subjects { get; }
			public Student() { }
			public Student(string name, int age, params Subject[] list)
			{
				if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException("請輸學生姓名"); }
				if (age < 1 || age > 100) { throw new ArgumentNullException("學生年齡怪怪的"); }
				Name = name;
				Age = age;
				Subjects = list.ToList();
			}
			public string Get_information()
			{
				var sb = new StringBuilder();

				foreach (Subject item in Subjects)
				{
					sb.Append(" " + item.SubjectName + ":");
					sb.Append(item.Score);
				}
				return $"HI~{Age}歲的{Name},您此次測試的成績...{sb}";
			}
			public string AverageScore()
			{
				double average = Subjects.Average(x => x.Score);
				string pass = (average >= 60) ? "此次平均及格喔~" : "此次平均不及格，請再加油。";
				return $"平均分數:{average},{pass}";
			}
			public string TotalScore()
			{
				int total = Subjects.Sum(x => x.Score);
				return $"總分:{total}";
			}
			public string HighestScore()
			{
				int highest = Subjects.Max(x => x.Score);
				string subjects = string.Empty;
				foreach (Subject item in Subjects)
				{
					if (highest == item.Score) { subjects = subjects + item.SubjectName + " "; }
				}
				return $"最高分:{highest},科目是:{subjects}";
			}
			public string LowestScore()
			{
				int lowest = Subjects.Min(x => x.Score);
				string subjects = string.Empty;
				foreach (Subject item in Subjects)
				{
					if (lowest == item.Score) { subjects = subjects + item.SubjectName + " "; }
				}
				return $"最低分:{lowest},科目是:{subjects}";
			}
		}
		public class Subject
		{
			public int Score { get; }
			public string SubjectName { get; }
			public Subject() { }
			public Subject(string subject, int score)
			{
				if (string.IsNullOrWhiteSpace(subject)) { throw new ArgumentNullException("尚未輸入科目"); }
				SubjectName = subject;
				if (score < 0 || score > 100) { throw new ArgumentOutOfRangeException("請輸入正確分數"); }
				Score = score;
			}
		}
	}
}
