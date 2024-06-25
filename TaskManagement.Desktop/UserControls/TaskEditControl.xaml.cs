using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using TaskManagement.DataBase.Entities;
using TaskManagement.Desktop.Models;
using TaskManagement.Desktop.Pages;
using TaskManagement.Desktop.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Desktop.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TaskEditControl.xaml
    /// </summary>
    public partial class TaskEditControl : UserControl
    {
        private TaskModel Task { get; set; }
        private ProjectsPageService ProjectsPageService { get; set; }
        public TaskEditControl(TaskModel task)
        {
            InitializeComponent();
            Task = task;
            if (Task == null)
                Task = new();
            DataContext = Task;
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await FillData();
        }
        private async Task FillData()
        {
            if (Task.Deadline == DateTime.MinValue)
                DeadlineDatePicker.SelectedDate = DateTime.Now;
            else
                TimeTb.Text = ConvertTimeToString(Task.Deadline);

            EmployeesCb.ItemsSource = await DbService.GetUsersAsync(AccessUser.Roles.Employee);
        }

        private string ConvertTimeToString(DateTime time)
        {
            string timeText = time.Hour < 10 ? $"0{time.Hour}" : $"{time.Hour}";
            timeText += ":";
            timeText += time.Minute < 10 ? $"0{time.Minute}" : $"{time.Minute}";
            return timeText;
        }

        private TimeSpan ConvertStringToTime(string timeString)
        {
            TimeSpan.TryParse(timeString, out TimeSpan time);
            return time;
        }

        private void TimeTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (TimeTb.Text.Length == 2)
            {
                TimeTb.Text += ":";
                TimeTb.CaretIndex = TimeTb.Text.Length;
            }
            if (TimeTb.Text.Length > 4)
                e.Handled = true;
            if (e.Text == ":" && TimeTb.Text.Contains(':'))
                e.Handled = true;
            Regex regex = new(@"\d");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
        }

		private async void SaveBtn_Click(object sender, RoutedEventArgs e)
		{
			string textError = ValidateValues().ToString();
			if (textError.Length != 0)
			{
				MessageBox.Show(textError, "Ошибка при заполнении данных", MessageBoxButton.OK);
				return;
			}
			bool succes = true;
			if (Task.Id == 0)
			{
				Task.ProjectId = Services.ProjectsPageService.ProjectId;
				Task.Id = await DbService.AddEntity(Task);
				HistoryChangeStatusTask historyChangeStatusTask = new()
				{
					TaskId = Task.Id,
					StatusId = (int)StatusModel.TaskStatuses.Created
				};
				await DbService.AddEntity(historyChangeStatusTask);
				succes = !DbService.SaveChangeError;
			}
			else
			{
				await DbService.UpdateEntity(Task);
				succes = !DbService.SaveChangeError;
			}
			if (succes)
				MessageBox.Show("Задача сохранена");
			else
				MessageBox.Show("Ошибка при сохранении задачи");
			ProjectsPageService service = new(Task.ProjectId);
			await ProjectsPageService.ProjectPage.LoadDataAsync();
			service.FillTasksInPage();

        }

        private async void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Действительно удалить задачу?",
                "Предупреждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
                return;
            await DbService.DeleteEntity(Task);
            await ProjectsPageService.LoadTasks(ProjectsPageService.ProjectModel);
        }

        private StringBuilder ValidateValues()
        {
            bool succesParseTime = TimeSpan.TryParse(TimeTb.Text, out TimeSpan time);
            StringBuilder textError = new();
            if (string.IsNullOrEmpty(Task.Name))
                textError.AppendLine("Не заполнено поле: Название задачи");
            if (string.IsNullOrEmpty(Task.Description))
                textError.AppendLine("Не заполнено поле: Описание");
            if (Task.UserId == 0)
                textError.AppendLine("Не выбран сотрудник для выполнения задачи");
            if (Task.Deadline.Date < DateTime.Now.Date)
                textError.AppendLine($"Дата дедлайна не может быть раньше сегодняшего дня({DateTime.Now.Date})");
            if (!new Regex(@"(\d){1,2}:(\d){1,2}").IsMatch(TimeTb.Text) || !succesParseTime)
                textError.AppendLine("Требуется указать время дедлайна в формате: чч:мм, где чч - часы(от 0 до 23), где мм - минуты(от 0 до 60)");

            return textError;
        }
    }
}
