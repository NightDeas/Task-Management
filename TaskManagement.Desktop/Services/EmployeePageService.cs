using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Desktop.Models;
using TaskManagement.Desktop.Pages;

namespace TaskManagement.Desktop.Services
{
	public static class EmployeePageService
	{
		public static EmployeePage EmployeePage { get; set; } = new();
		public static List<UserModel> Users { get; set; } = new();
		public static async void LoadUsers()
		{
			var users = await DbService.GetUsersAsync();
			Users = new UserModel().ToModel(users);
			EmployeePage.EmployeeControlsStackPanel.Children.Clear();
			foreach (var user in Users)
			{
				EmployeePage.EmployeeControlsStackPanel.Children.Add(new UserControls.EmployeeControl(user));
			}
		}
	}
}
