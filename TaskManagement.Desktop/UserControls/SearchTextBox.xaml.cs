using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
using TaskManagement.DataBase.Migrations;
using TaskManagement.Desktop.Services;

namespace TaskManagement.Desktop.UserControls
{
    public partial class SearchTextBox : UserControl
    {

        public enum EntityTypes
        {
            Project,
            Task,
            Employee
        }
        private string hintText;
        private string searchText;

        public static readonly DependencyProperty EntityTypeProperty =
     DependencyProperty.Register("EntityType", typeof(EntityTypes), typeof(SearchTextBox), new PropertyMetadata(EntityTypes.Project));

        public static readonly DependencyProperty HintTextProperty =
            DependencyProperty.Register("HintText", typeof(string), typeof(SearchTextBox), new("Поиск"));

        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(SearchTextBox), null);

        public string SearchText { get => (string)GetValue(SearchTextProperty); set => SetValue(SearchTextProperty, value); }

        public EntityTypes EntityType { get => (EntityTypes)GetValue(EntityTypeProperty); set => SetValue(EntityTypeProperty, value); }
        public string HintText
        {
            get => (string)GetValue(HintTextProperty); set
            {
                if (string.IsNullOrEmpty(value))
                {
                    SetValue(HintTextProperty, "Поиск");
                }
                else
                    SetValue(HintTextProperty, value);
            }

        }

        public SearchTextBox()
        {
            InitializeComponent();
            DataContext = this;
        }



        private async Task Search(string searchText)
        {
            switch (EntityType)
            {
                case EntityTypes.Project:
                    Services.ProjectsPageService.ProjectPage.LoadDataAsync(searchText);
                    break;
                case EntityTypes.Task:
                    ProjectsPageService service = new(ProjectsPageService.ProjectId);
                    service.FillTasksInPage(searchText);

                    break;
                case EntityTypes.Employee:
                    break;
                default:
                    break;
            }
        }

        private async void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
                await Search(textBox.Text);
        }
    }
}
