using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
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
using TaskManagement.Desktop.UserControls;

namespace TaskManagement.Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProjectPage.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        private List<ProjectModel> _projects = new();
        private Services.ProjectsPageService _ProjectsPageService;
        public ProjectPage()
        {
            InitializeComponent();
            ProjectsPageService.ProjectPage = this;
        }

        public async System.Threading.Tasks.Task LoadDataAsync()
        {
            List<Project> projects = new();
            projects = await DbService.GetProjectsAsync();
            var tasks = await DbService.GetHistoryChangeStatusTask();
            var groupTasks = tasks.GroupBy(x => x.Task).Select(x => x.Last()).ToList();
            var historyChangeStatus = await DbService.GetHistoryChangeStatusTask();
            FillProjects(projects, groupTasks, historyChangeStatus);
            FillStackPanel();
        }

        public async System.Threading.Tasks.Task LoadDataAsync(string textSearch)
        {
            List<Project> projects = await DbService.GetProjectsAsync(textSearch);
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
                ProjectControl control = new UserControls.ProjectControl(project);
                if (StylesService.ProjectControl != null && StylesService.ProjectControl.Project.Id == project.Id)
                    StylesService.SetActiveStyle(control);
                ProjectsStackPanel.Children.Add(control);
            }
        }

        private void FillProjects(List<Project> projects, List<DataBase.Entities.HistoryChangeStatusTask> tasks, List<DataBase.Entities.HistoryChangeStatusTask> historyChangeStatusTasks)
        {
            _projects = new();
            foreach (var project in projects)
            {
                var tasksProject = tasks.Where(x => x.Task.ProjectId == project.Id)
                    .GroupBy(x => x.TaskId)
                    .Select(g => g.LastOrDefault())
                    .ToList();
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
            StylesService.Reset();
            ProjectsPageService.ClearTasksInPage();
            ProjectsPageService.ProjectPage.TaskCreateBtn.Visibility = Visibility.Collapsed;
            if (!Services.AccessUser.CheckAccess(AccessUser.Roles.Admin))
                return;
            ProjectsPageService.OpenEditProject(null, true);

        }

        private async void TaskCreateBtn_Click(object sender, RoutedEventArgs e)
        {
            StylesService.Reset(StylesService.Controls.Task);
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
