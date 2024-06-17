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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            UserService.ResetUser();
            App.MainWindow.ExitBtn.Visibility = Visibility.Collapsed;
        }

        private async void Auth_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text) || string.IsNullOrEmpty(PasswordPb.Password))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            var user = await DbService.GetUserAsync(LoginTb.Text, PasswordPb.Password);
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }
            UserService.SetUser(user);
            App.MainWindow.FrameMain.Navigate(new Pages.MainPage());
            App.MainWindow.ExitBtn.Visibility = Visibility.Visible;
        }
    }
}
