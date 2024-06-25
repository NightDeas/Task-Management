using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Xml;
using TaskManagement.Desktop.Models;
using TaskManagement.Desktop.Pages;
using TaskManagement.Desktop.Services;

namespace TaskManagement.Desktop.UserControls
{
	/// <summary>
	/// Логика взаимодействия для ProjectEditControl.xaml
	/// </summary>
	public partial class ProjectEditControl : UserControl
	{
		ProjectModel Project;
		bool Edit;
		public enum Types
		{
			Create,
			Update,
			Information
		}
		public ProjectEditControl(ProjectModel project, Types type)
		{
			InitializeComponent();
			Edit = type == Types.Information? false : true;
			Project = project;
			ConfigPage();
			if (Project == null)
				Project = new();
			DataContext = Project;
			CreateProjectAdminsList();
		}

		private void ConfigPage()
		{
			switch (Edit)
			{
				case true:
					NameTb.IsEnabled = true;
					DeleteBtn.Visibility = Visibility.Visible;
					SaveBtn.Visibility = Visibility.Visible;
					TitleTb.Text = "Управление проектом";
					break;
				case false:
					NameTb.IsEnabled = false;
					DeleteBtn.Visibility = Visibility.Collapsed;
					SaveBtn.Visibility = Visibility.Collapsed;
					TitleTb.Text = "Информация о проекте";
					break;
			}
			if (Project == null)
			{
				DeleteBtn.Visibility = Visibility.Collapsed;
				TitleTb.Text = "Создание проекта";
			}
			else
				DeleteBtn.Visibility = Visibility.Visible;
		}

		private void CreateProjectAdminsList()
		{
			UserControls.ProjectAdministratorListControl projectAdministratorListControl = new(Project.Id, Edit);
			projectAdministratorListControl.SetValue(Grid.RowProperty, 2);
			projectAdministratorListControl.SetValue(Grid.ColumnSpanProperty, 2);
			MainGrid.Children.Add(projectAdministratorListControl);
		}

		private async void SaveBtn_Click(object sender, RoutedEventArgs e)
		{
			string textError = ValidateValues().ToString();
			if (textError.Length != 0)
			{
				MessageBox.Show(textError, "Ошибка при заполнении данных", MessageBoxButton.OK);
				return;
			}

			Services.ProjectAdministratorInProjectService projectAdministratorInProjectService = new();
			bool success;
			bool isNew;
			int projectId = 0;
			if (Project.Id == 0)
			{
				projectId = await DbService.AddEntity(Project);
				Project.Id = projectId;
				success = !DbService.SaveChangeError;
				isNew = true;
			}
			else
			{
				//await DbService.UpdateEntity(Project);
				success = !DbService.SaveChangeError;
				isNew = false;
			}
			if (isNew)
			{
				await projectAdministratorInProjectService.AddListEntitiesInBd(Project.Id);
				success = !DbService.SaveChangeError;
			}
			else
			{
				await projectAdministratorInProjectService.UpdateListEntitiesInBd(Project.Id);
				success = !DbService.SaveChangeError;
			}
			if (success)
				MessageBox.Show("Проект сохранен");
			else
				MessageBox.Show("Ошибка при сохранении проекта");
			projectAdministratorInProjectService.ResetList();
			await ProjectsPageService.ProjectPage.LoadDataAsync();


		}

        private StringBuilder ValidateValues()
		{
			StringBuilder textError = new();
			if (string.IsNullOrEmpty(Project.Name))
				textError.Append("Не заполнено поле: Название проекта");
			return textError;
		}

		private async void DelteBtn_Click(object sender, RoutedEventArgs e)
		{
			var result = MessageBox.Show("Действительно удалить?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (result != MessageBoxResult.Yes)
				return;
			await DbService.DeleteEntity(Project);
			bool success = !DbService.SaveChangeError;
			if (success)
				MessageBox.Show("Проект удален");
			else
				MessageBox.Show("Ошибка при удалении проекта");
			await ProjectsPageService.LoadProjectsAsync();


        }
	}
}
