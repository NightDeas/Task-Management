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
        List<Models.User> ProjectsAdministrators { get; set; }
        public ProjectAdministratorListControl()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ProjectsAdministrators = await DbService.GetUsersAsync(2); // 2 - администратор проекта
            FillStackPanel(ProjectsAdministrators);
        }
        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = SearchTb.Text;
            if (text.Length == 0)
            {
                FillStackPanel(ProjectsAdministrators);
                return;
            }
            var resultSearch = ProjectsAdministrators.Where(x =>
            x.LastName.Contains(text, StringComparison.OrdinalIgnoreCase) ||
            x.FirstName.Contains(text, StringComparison.OrdinalIgnoreCase) ||
            x.Patronymic.Contains(text, StringComparison.OrdinalIgnoreCase))
                .ToList();
            FillStackPanel(resultSearch);
        }

        private void FillStackPanel(List<Models.User> projectsAdministrators)
        {
            ListProjectAdministratorsStackPanel.Children.Clear();
            foreach (var projectAdmin in projectsAdministrators)
            {
                ListProjectAdministratorsStackPanel.Children.Add(new UserControls.ProjectAdministratorControl(projectAdmin));
            }
        }
    }
}
