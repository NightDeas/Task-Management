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
using System.Xml;
using TaskManagement.Desktop.Models;
using TaskManagement.Desktop.Services;

namespace TaskManagement.Desktop.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProjectEditControl.xaml
    /// </summary>
    public partial class ProjectEditControl : UserControl
    {
        ProjectModel Project;
        public ProjectEditControl(ProjectModel project)
        {
            InitializeComponent();
            Project = project;
            if (Project == null)
                Project = new();
            DataContext = Project;
        }

        private async void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            bool success;
            if (Project.Id == 0)
                success = await DbService.AddEntity(Project);
            else
                success = await DbService.UpdateEntity(Project);
            if (success)
                MessageBox.Show("Проект добавлен");
            else
                MessageBox.Show("Ошибка при добавлении проекта");
        }

        private async void DelteBtn_Click(object sender, RoutedEventArgs e)
        {
            bool success = await DbService.DeleteEntity(Project);
            if (success)
                MessageBox.Show("Проект удален");
            else
                MessageBox.Show("Ошибка при удалении проекта");
        }
    }
}
