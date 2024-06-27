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
using TaskManagement.DataBase.Entities;
using TaskManagement.Desktop.Models;
using TaskManagement.Desktop.Services;

namespace TaskManagement.Desktop.UserControls
{
	/// <summary>
	/// Логика взаимодействия для TaskInfoControl.xaml
	/// </summary>
	public partial class TaskInfoControl : UserControl
	{
		TaskModel Task { get; set; }
		ProjectsPageService ProjectsPageService { get; set; }
		public TaskInfoControl(TaskModel model)
		{
			InitializeComponent();
			this.Task = model;
			DataContext = Task;
			ProjectsPageService = new(Task.ProjectId);
			ConfigButtons();
		}

		private void ConfigButtons()
		{
			List<Button> buttons = new();
			AccessUser.Roles userRole = AccessUser.GetRoleUser();
			if (userRole == AccessUser.Roles.Admin || userRole == AccessUser.Roles.ProjectAdministrator)
			{
				EditBtn.Visibility = Visibility.Visible;
				buttons.Add(EditBtn);
			}
			if ((userRole == AccessUser.Roles.Admin || userRole == AccessUser.Roles.ProjectAdministrator) &&
				Task.Status.Id == (int)StatusModel.TaskStatuses.Checking)
			{
				BackTaskBtn.Visibility = Visibility.Visible;
				buttons.Add(BackTaskBtn);
			}
			if ((userRole == AccessUser.Roles.Admin || userRole == AccessUser.Roles.ProjectAdministrator) &&
				Task.Status.Id != (int)StatusModel.TaskStatuses.Closed)
			{
				CloseTaskBtn.Visibility = Visibility.Visible;
				buttons.Add(CloseTaskBtn);
			}
			if (userRole == AccessUser.Roles.Employee &&
				Task.Status.Id == (int)StatusModel.TaskStatuses.Checking)
			{
				SendTaskBtn.Visibility = Visibility.Visible;
				buttons.Add(SendTaskBtn);
			}


			int row = 0;
			int column = 0;
			//Предупреждение: Следите за количеством строк в Grid
			foreach (var button in buttons)
			{
				if (column == ButtonsGrid.ColumnDefinitions.Count - 1)
				{
					row++;
					column = 0;
				}
				button.SetValue(Grid.ColumnProperty, column++);
				button.SetValue(Grid.RowProperty, row);
			}
		}

		private async void EditBtn_Click(object sender, RoutedEventArgs e)
		{
			bool access = await ProjectAdministratorService.AccessEditProject(ProjectsPageService.ProjectId) || AccessUser.CheckAccess(AccessUser.Roles.Admin);
			if (!access)
			{
				AccessUser.Message(AccessUser.Access.Forbidden, AccessUser.Roles.Admin);
				return;
			}
			ProjectsPageService.ProjectPage.EditorControlGrid.Children.Clear();
			ProjectsPageService.ProjectPage.EditorControlGrid.Children.Add(new UserControls.TaskEditControl(Task));
		}


		private async void SendTaskBtn_Click(object sender, RoutedEventArgs e)
		{
			HistoryChangeStatusTask historyChangeStatusTask = new HistoryChangeStatusTask()
			{
				TaskId = Task.Id,
				StatusId = (int)StatusModel.TaskStatuses.Checking,
			};
			await DbService.AddEntity(historyChangeStatusTask);
			if (!DbService.SaveChangeError)
				MessageBox.Show(@"Задание помечено как ""Отправлено на проверку""");
			else
				MessageBox.Show("Ошибка при отправки задания");
			ProjectsPageService.FillTasksInPage(ProjectsPageService.ProjectId);
		}

		private async void CloseTaskBtn_Click(object sender, RoutedEventArgs e)
		{
			HistoryChangeStatusTask historyChangeStatusTask = new HistoryChangeStatusTask()
			{
				TaskId = Task.Id,
				StatusId = (int)StatusModel.TaskStatuses.Closed,
			};
			await DbService.AddEntity(historyChangeStatusTask);
			if (!DbService.SaveChangeError)
				MessageBox.Show(@"Задание помечено как ""Закрыто""");
			else
				MessageBox.Show("Ошибка при закрытии задачи");
		}

		private async void BackTaskBtn_Click(object sender, RoutedEventArgs e)
		{
			HistoryChangeStatusTask historyChangeStatusTask = new HistoryChangeStatusTask()
			{
				TaskId = Task.Id,
				StatusId = (int)StatusModel.TaskStatuses.CancelByAdmin,
			};
			await DbService.AddEntity(historyChangeStatusTask);
			if (!DbService.SaveChangeError)
				MessageBox.Show(@"Задание помечено как ""Возвращено руководителем""");
			else
				MessageBox.Show("Ошибка при возвращении задачи");
		}
	}
}
