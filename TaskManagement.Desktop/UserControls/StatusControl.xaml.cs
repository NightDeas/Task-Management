using Microsoft.EntityFrameworkCore.Diagnostics;
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
    /// Логика взаимодействия для StatusControl.xaml
    /// </summary>
    public partial class StatusControl : UserControl
    {
        private DataBase.Entities.Status Status { get; set; }
        public StatusControl()
        {
            InitializeComponent();
        }
        public StatusControl(int statusId) : this()
        {
            LoadData(statusId);
            FillBorder();
            DataContext = Status;
        }

        public StatusControl(DataBase.Entities.Status status) : this()
        {
            Status = status;
            FillBorder();
            DataContext = Status;
        }


        private void FillBorder()
        {
            switch (Status.Id)
            {
                case 1:
                    border.Background = new SolidColorBrush(Colors.Green);
                    break;
                case 2:
                    border.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case 3:
                    border.Background = new SolidColorBrush(Colors.DarkGoldenrod);
                    break;
                case 4:
                    border.Background = new SolidColorBrush(Colors.Red);
                    break;
                case 5:
                    border.Background = new SolidColorBrush(Colors.DarkGray);
                    break;
                default:
                    break;
            }
        }

        private async void LoadData(int statusId)
        {
            Status = await DbService.GetStatusAsync(statusId);
        }

    }
}
