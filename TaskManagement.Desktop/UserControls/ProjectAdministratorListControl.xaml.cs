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
	/// Логика взаимодействия для ProjectAdministratorListControl.xaml
	/// </summary>
	public partial class ProjectAdministratorListControl : UserControl
	{
		List<Models.UserModel> ProjectsAdministrators { get; set; }
		private int ProjectId { get; set; }
		private bool OnlySelected { get; set; }
		public ProjectAdministratorListControl()
		{
			InitializeComponent();
		}

		public ProjectAdministratorListControl(int projectId, bool onlySelected) : this()
		{
			ProjectId = projectId;
			OnlySelected = onlySelected;
		}

		private async void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			var usersModels = new Models.UserModel().ToModel(await DbService.GetUsersAsync(AccessUser.Roles.ProjectAdministrator));
			ProjectsAdministrators = usersModels;
			Services.ProjectAdministratorInProjectService service = new();
			service.ResetList();
			await FillStackPanel(ProjectsAdministrators);
		}
		private async void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
		{
			string text = SearchTb.Text;
			if (text.Length == 0)
			{
				await FillStackPanel(ProjectsAdministrators);
				return;
			}
			var resultSearch = ProjectsAdministrators.Where(x =>
			x.LastName.Contains(text, StringComparison.OrdinalIgnoreCase) ||
			x.FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) ||
			x.Patronymic.Contains(text, StringComparison.OrdinalIgnoreCase))
				.ToList();
			await FillStackPanel(resultSearch);
		}

		private async Task FillStackPanel(List<Models.UserModel> projectsAdministrators)
		{
			ListProjectAdministratorsStackPanel.Children.Clear();
			List<DataBase.Entities.User> projectAdminsInProject = new();
			if (ProjectId != 0)
				projectAdminsInProject = await DbService.GetProjectAdminstratorInProject(ProjectId);
			switch (!OnlySelected)
			{
				case true:
					foreach (var projectAdmin in projectsAdministrators)
					{
						bool availability = projectAdminsInProject.Any(x => x.Id == projectAdmin.Id);
						if (availability)
							ListProjectAdministratorsStackPanel.Children.Add(new UserControls.ProjectAdministratorControl(projectAdmin, availability));
					}
					break;
				case false:
					foreach (var projectAdmin in projectsAdministrators)
					{
						bool availability = projectAdminsInProject.Any(x => x.Id == projectAdmin.Id);
						ListProjectAdministratorsStackPanel.Children.Add(new UserControls.ProjectAdministratorControl(projectAdmin, availability));
					}
					break;
			}

		}

	

	}
}
