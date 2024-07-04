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

namespace TaskManagement.Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void ProjectBtn_Click(object sender, RoutedEventArgs e)
        {
            Services.MenuPageService.SetActiveStyleButton(ProjectBtn);
            Frame.Navigate(new Pages.ProjectPage());
        }

        //private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Services.MenuPageService.SetActiveStyleButton(EmployeeBtn);
        //    Frame.Navigate(new Pages.EmployeePage());
        //}

        //private void StatisticsBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Services.MenuPageService.SetActiveStyleButton(StatisticsBtn);
        //}
    }
}
