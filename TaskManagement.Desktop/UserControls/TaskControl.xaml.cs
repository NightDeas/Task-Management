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

namespace TaskManagement.Desktop.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        TaskModel Task { get; set; }
        public TaskControl(Models.TaskModel task)
        {
            InitializeComponent();
            Task = task;
            DataContext = Task;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UserControls.StatusControl statusControl = new UserControls.StatusControl(Task.Status);
            statusControl.SetValue(Grid.ColumnProperty, 2);
            ContentGrid.Children.Add(statusControl); 
        }
    }
}
