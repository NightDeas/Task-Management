using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

namespace TaskManagement.Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProjectPage.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        private List<ProjectModel> _projects = new();
        private Services.ProjectsPageService ProjectsPageService;
        public ProjectPage()
        {
            InitializeComponent();
            ProjectsPageService.ProjectPage = this;
        }

        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            List<Project> projects = new();
            if (UserService.GetUser().Role.Id == 3)
                projects = await DbService.GetProjectsAsync(UserService.GetUser().Id);
            if (UserService.GetUser().Role.Id == 2)
                projects = await DbService.GetProjectsAsync(UserService.GetUser().Id, UserService.GetUser().Role.Id);
            if (UserService.GetUser().Role.Id == 1)
                projects = await DbService.GetProjectsAsync();
            var tasks = await DbService.GetHistoryChangeStatusTask();
            var groupTasks = tasks.GroupBy(x => x.Task).Select(x => x.Last()).ToList();
            var historyChangeStatus = await DbService.GetHistoryChangeStatusTask();
            FillProjects(projects, groupTasks, historyChangeStatus);
            FillStackPanel();
        }

        private void FillStackPanel()
        {
            ProjectsStackPanel.Children.Clear();
            foreach (var project in _projects)
            {
                ProjectsStackPanel.Children.Add(new UserControls.ProjectControl(project));
            }
        }

        private void FillProjects(List<Project> projects, List<DataBase.Entities.HistoryChangeStatusTask> tasks, List<DataBase.Entities.HistoryChangeStatusTask> historyChangeStatusTasks)
        {
            foreach (var project in projects)
            {
                var tasksProject = tasks.Where(x => x.Task.ProjectId == project.Id).ToList();
                int countTasks = tasksProject.Count;
                var countCompletedTask = tasksProject.Where(x => x.StatusId == 5).Count();
                var countNotCompletedTask = tasksProject.Where(x => x.StatusId != 5).Count();
                _projects.Add(new ProjectModel()
                {
                    Id = project.Id,
                    Name = project.Name,
                    CountTasks = countTasks,
                    CountCompletedTasks = countCompletedTask,
                    CountNotCompletedTasks = countNotCompletedTask
                });
            }
        }

        private async void Page_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync();
        }

        private void ProjectCreateBtn_Click(object sender, RoutedEventArgs e)
        {
			ProjectsPageService.ClearTasksInPage();
            ProjectsPageService.ProjectPage.TaskCreateBtn.Visibility = Visibility.Collapsed;
            if (!Services.AccessUser.CheckAccess(AccessUser.Roles.Admin))
                return;
            EditorControlGrid.Children.Clear();
            EditorControlGrid.Children.Add(new UserControls.ProjectEditControl(null, true));
        }

		private async void TaskCreateBtn_Click(object sender, RoutedEventArgs e)
		{
            bool access = await Services.ProjectAdministratorService.AccessEditProject(ProjectsPageService.ProjectId);
			if (!(AccessUser.GetRoleUser() == AccessUser.Roles.Admin || access))
            {
                AccessUser.Message(AccessUser.Access.Forbidden, AccessUser.Roles.ProjectAdministrator);
				return;
            }
			EditorControlGrid.Children.Clear();
			EditorControlGrid.Children.Add(new UserControls.TaskEditControl(null));
		}
	}
}
