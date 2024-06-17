using System.Configuration;
using System.Data;
using System.Windows;

namespace TaskManagement.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow MainWindow;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            MainWindow = new MainWindow();
            MainWindow.FrameMain.Navigate(new Pages.LoginPage());
            MainWindow.ShowDialog();
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show($"{e.Exception.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

}
