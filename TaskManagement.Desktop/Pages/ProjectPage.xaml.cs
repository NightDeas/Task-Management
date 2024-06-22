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
        public ProjectPage()
        {
            InitializeComponent();
            ProjectsPageService.ProjectPage = this;
        }

        

        private async void Page_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await ProjectsPageService.LoadProjectsAsync();
        }

        private void ProjectCreateBtn_Click(object sender, RoutedEventArgs e)
        {
            StylesService.Reset();
			ProjectsPageService.ClearTasksInPage();
            ProjectsPageService.ProjectPage.TaskCreateBtn.Visibility = Visibility.Collapsed;
            if (!Services.AccessUser.CheckAccess(AccessUser.Roles.Admin))
                return;
            EditorControlGrid.Children.Clear();
            EditorControlGrid.Children.Add(new UserControls.ProjectEditControl(null, true));
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
