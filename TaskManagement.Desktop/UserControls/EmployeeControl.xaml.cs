using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManagement.Desktop.Services;

namespace TaskManagement.Desktop.UserControls
{
	/// <summary>
	/// Логика взаимодействия для EmployeeControl.xaml
	/// </summary>
	public partial class EmployeeControl : UserControl
	{
		public Models.UserModel User { get; set; }
		public int CountCompletedTasks { get; set; }
		public int CountNotCompletedTasks { get;set; }
		public EmployeeControl(Models.UserModel user)
		{
			InitializeComponent();
			User = user ?? new();
			LoadData();
			DataContext = this;
		}

		private async void LoadData()
		{
			CountCompletedTasks = await DbService.GetCountCompletedTasksByUserAsync(User.Id);
			CountNotCompletedTasks = await DbService.GetCountNotCompletedTasksByUserAsync(User.Id);
		}
	}
}
