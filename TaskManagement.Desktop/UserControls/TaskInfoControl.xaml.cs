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
        public TaskInfoControl(TaskModel model)
        {
            InitializeComponent();
            this.Task = model;
            DataContext = Task;
        }

        private async void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            bool access = await ProjectAdministratorService.AccessEditProject(ProjectsPageService.ProjectId) || AccessUser.CheckAccess(AccessUser.Roles.Admin);
            if (!access)
            {
                AccessUser.Message(AccessUser.Access.Forbidden);
                return;
            }
            ProjectsPageService.ProjectPage.EditorControlGrid.Children.Clear();
            ProjectsPageService.ProjectPage.EditorControlGrid.Children.Add(new UserControls.TaskEditControl(Task));
        }
    }
}
