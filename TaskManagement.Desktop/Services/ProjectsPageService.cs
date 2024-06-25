using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagement.Desktop.Models;
using TaskManagement.Desktop.Pages;

namespace TaskManagement.Desktop.Services
{
	public class ProjectsPageService
	{
		public static Pages.ProjectPage ProjectPage { get; set; }

		public static int ProjectId { get; set; }
		public ProjectsPageService(int projectId)
		{
			ProjectId = projectId;
		}

		public async void FillTasksInPage()
		{
			ClearTasksInPage();
			var tasks = await DbService.GetHistoryChangeStatusTaskAsync(ProjectId);
			foreach (var task in tasks)
			{
				ProjectPage.TasksStackPanel.Children.Add(new UserControls.TaskControl(TaskModel.ToModel(task)));
			}
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
