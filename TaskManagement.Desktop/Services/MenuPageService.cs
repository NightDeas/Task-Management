using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TaskManagement.Desktop.Services
{
    public static class MenuPageService
    {
        public static Button ActiveButton { get; set; }
        public static string TitlePage { get; set; }


        public static void SetActiveStyleButton(Button button)
        {
            if (ActiveButton != null && ActiveButton != button)
            {
                ActiveButton.Style = (Style)App.Current.FindResource("DefaultButton");
            }
            ActiveButton = button;
            ActiveButton.Style = (Style)App.Current.FindResource("ActiveButton");
            
        }
    }
}
