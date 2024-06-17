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

        public int ProjectId { get; set; }
        public ProjectsPageService(int projectId)
        {
            ProjectId = projectId;
        }

        public async void FillTasksInPage()
        {
            ProjectPage.TasksStackPanel.Children.Clear();
            var tasks = await DbService.GetHistoryChangeStatusTaskAsync(ProjectId);
            foreach (var task in tasks)
            {
                ProjectPage.TasksStackPanel.Children.Add(new UserControls.TaskControl(TaskModel.ToModel(task)));
            }
        }

        public async void FillTasksInPage(int EmployeeId)
        {
            ProjectPage.TasksStackPanel.Children.Clear();
            var historyChangeStatuses = await DbService.GetHistoryChangeStatusTaskAsync(ProjectId, EmployeeId);
            foreach (var historyChangeStatus in historyChangeStatuses)
            {
                ProjectPage.TasksStackPanel.Children.Add(new UserControls.TaskControl(TaskModel.ToModel(historyChangeStatus)));
            }
        }
    }
}
