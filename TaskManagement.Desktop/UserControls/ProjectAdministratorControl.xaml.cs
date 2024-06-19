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

namespace TaskManagement.Desktop.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProjectAdministratorControl.xaml
    /// </summary>
    public partial class ProjectAdministratorControl : UserControl
    {
        Models.User User { get; set; }
        bool Active { get; set; }
        Services.ProjectAdministratorInProjectService Service = new();
        public ProjectAdministratorControl(Models.User user, bool active)
        {
            InitializeComponent();
            User = user;
            Active = active;
            FullNameTb.DataContext = User;
            AvialableCb.IsChecked = Active;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Service.AddUser(User);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Service.DeleteUser(User);
        }
    }
}
