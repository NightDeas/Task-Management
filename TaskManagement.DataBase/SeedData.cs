using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.DataBase
{
	public static class SeedData
	{
		public static string[] LastNames = new[] {
			"Иванов", "Александров", "Буранов",
			"Печкин", "Петров", "Харизматов",
			"Сидоров", "Серлов", "Ивашкин",
		"Куколович", "Гримов", "Гераклов"};

		public static string[] FirstNames = new[]
		{
			"Сергей","Александр","Иван",
			"Петр","Алексей","Максим",
			"Даниил","Никита","Григорий",
			"Юрий","Владислав","Павел",
		};

		public static string[] Patronymics = new[]
	{
			"Сергеевич","Александрович","Иванович",
			"Петрович","Алексеевич","Максимович",
			"Даниилович","Никитович","Григорьевич",
			"Юрьевич","Владиславович","Павлович",
		};


		/// <summary>
		/// Генерация серии и номера с паспорта с разделителем пробелом
		/// </summary>
		/// <returns></returns>
		public static string GeneratePassport()
		{
			return $"{Random.Shared.Next(1000, 9999)} {Random.Shared.Next(100000, 999999)}";
		}

		public static DateTime GenerateDate()
		{
			Random random = new Random();
			int year = random.Next(1970, DateTime.Today.Year);
			int month = random.Next(1, 12);
			int day = random.Next(1, DateTime.DaysInMonth(year, month));
			return new DateTime(year, month, day);
		}

		public static string GetLastName()
		{
			return LastNames[Random.Shared.Next(LastNames.Length-1)];
		}

		public static string GetFirstName()
		{
			return FirstNames[Random.Shared.Next(FirstNames.Length - 1)];
		}

		public static string GetPatronymic()
		{
			return Patronymics[Random.Shared.Next(Patronymics.Length - 1)];
		}


	}
}
