using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagement.DataBase.Entities;
using TaskManagement.Desktop.Models;
using TaskManagement.Desktop.Pages;
using TaskManagement.Desktop.UserControls;

namespace TaskManagement.Desktop.Services
{
	public class ProjectsPageService
	{
		public static Pages.ProjectPage ProjectPage { get; set; }
        private static List<ProjectModel> _projects = new();

        public static int ProjectId { get; set; }
        public static ProjectModel ProjectModel { get; set; }
		public ProjectsPageService(int projectId)
		{
			ProjectId = projectId;
		}


        public static async System.Threading.Tasks.Task LoadProjectsAsync()
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

        public async System.Threading.Tasks.Task LoadTasks(ProjectModel project)
        {
            switch (Services.AccessUser.GetRoleUser())
            {
                case AccessUser.Roles.Admin:
                    FillTasksInPage();
                    OpenEditProject(project, true);
                    break;
                case AccessUser.Roles.ProjectAdministrator:
                    FillTasksInPage();
                    OpenEditProject(project, false);
                    break;
                case AccessUser.Roles.Employee:
                    FillTasksInPage(UserService.GetUser().Id);
                    OpenEditProject(project, false);
                    break;
                default:
                    throw new Exception("Отсуствует роль");
            }
        }

        private static void FillStackPanel()
        {
            ProjectPage.ProjectsStackPanel.Children.Clear();
            foreach (var project in _projects)
            {
                ProjectPage.ProjectsStackPanel.Children.Add(new UserControls.ProjectControl(project));
            }
        }

        private static void FillProjects(List<Project> projects, List<DataBase.Entities.HistoryChangeStatusTask> tasks, List<DataBase.Entities.HistoryChangeStatusTask> historyChangeStatusTasks)
        {
            _projects = new();
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

        public async void FillTasksInPage()
		{
			ClearTasksInPage();
            var tasks = await DbService.GetHistoryChangeStatusTaskAsync(ProjectId);
			foreach (var task in tasks)
			{
                TaskControl control = (new UserControls.TaskControl(TaskModel.ToModel(task)));
                if (StylesService.TaskControl != null && StylesService.TaskControl.Task.Id == task.TaskId)
                    StylesService.SetActiveStyle(control);
                ProjectPage.TasksStackPanel.Children.Add(control);
			}
			ProjectPage.ScroolTasks.Visibility = System.Windows.Visibility.Visible;
		}

		public async void FillTasksInPage(string searchText)
        {
            ClearTasksInPage();
            var tasks = await DbService.GetHistoryChangeStatusTaskAsync(ProjectId, searchText);
            foreach (var task in tasks)
            {
                TaskControl control = (new UserControls.TaskControl(TaskModel.ToModel(task)));
                if (StylesService.TaskControl != null && StylesService.TaskControl.Task.Id == task.TaskId)
                    StylesService.SetActiveStyle(control);
                ProjectPage.TasksStackPanel.Children.Add(control);
            }
            ProjectPage.ScroolTasks.Visibility = System.Windows.Visibility.Visible;
        }

        public async void FillTasksInPage(int EmployeeId)
		{
			ClearTasksInPage();
			var historyChangeStatuses = await DbService.GetHistoryChangeStatusTaskAsync(ProjectId, EmployeeId);
			foreach (var historyChangeStatus in historyChangeStatuses)
			{
				ProjectPage.TasksStackPanel.Children.Add(new UserControls.TaskControl(TaskModel.ToModel(historyChangeStatus)));
			}
		}

		public static void ClearTasksInPage()
		{
			ProjectPage.TasksStackPanel.Children.Clear();
		}

		public static void OpenEditProject(ProjectModel project, bool allowEdit)
		{
			UserControls.ProjectEditControl.Types typeOperation = allowEdit == true ? UserControls.ProjectEditControl.Types.Update : UserControls.ProjectEditControl.Types.Information;
			ProjectPage.EditorControlGrid.Children.Clear();
			UserControls.ProjectEditControl projectEditControl = new(project, typeOperation);
			ProjectPage.EditorControlGrid.Children.Add(projectEditControl);
		}
	}
}
