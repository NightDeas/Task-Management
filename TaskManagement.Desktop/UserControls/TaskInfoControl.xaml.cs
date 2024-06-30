using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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
using TaskManagement.Desktop.Services;

namespace TaskManagement.Desktop.UserControls
{
    /// <summary>
    /// Логика взаимодействия для TaskInfoControl.xaml
    /// </summary>
    public partial class TaskInfoControl : UserControl
    {
        TaskModel Task { get; set; }
        ProjectsPageService ProjectsPageService { get; set; }
        public TaskInfoControl(TaskModel model)
        {
            InitializeComponent();
            this.Task = model;
            DataContext = Task;
            ProjectsPageService = new(Task.ProjectId);
            ConfigButtons();
            DeadLineTextBlockConfig();
        }

        private void DeadLineTextBlockConfig()
        {
            if (Task.Deadline <= DateTime.Now.AddDays(-3))
                DeadlineTb.Foreground = new SolidColorBrush(Colors.DarkOrange);
            if (Task.Deadline <= DateTime.Now)
                DeadlineTb.Foreground = new SolidColorBrush(Colors.Red);
        }

        private void ConfigButtons()
        {
            List<Button> buttons = new();
            AccessUser.Roles userRole = AccessUser.GetRoleUser();
            //Редактирование задачи только для админа и проект администратора
            if (userRole == AccessUser.Roles.Admin || userRole == AccessUser.Roles.ProjectAdministrator)
            {
                EditBtn.Visibility = Visibility.Visible;
                buttons.Add(EditBtn);
            }
            //Вернуть задачу, которая была отправлена сотрудником. Доступ админ и проект админ
            if ((userRole == AccessUser.Roles.Admin || userRole == AccessUser.Roles.ProjectAdministrator) &&
                Task.Status.Id == (int)StatusModel.TaskStatuses.Checking)
            {
                BackTaskBtn.Visibility = Visibility.Visible;
                buttons.Add(BackTaskBtn);
            }
            //Закрыть задачу, которая находится на проверке. Доступ админ и проект админ
            if ((userRole == AccessUser.Roles.Admin || userRole == AccessUser.Roles.ProjectAdministrator) &&
                Task.Status.Id != (int)StatusModel.TaskStatuses.Closed)
            {
                CloseTaskBtn.Visibility = Visibility.Visible;
                buttons.Add(CloseTaskBtn);
            }
            //Отправить задачу на проверку. Доступ сотрудник
            if (userRole == AccessUser.Roles.Employee &&
                Task.Status.Id == (int)StatusModel.TaskStatuses.Work)
            {
                SendTaskBtn.Visibility = Visibility.Visible;
                buttons.Add(SendTaskBtn);
            }
            //Отправить задачу на проверку. Доступ сотрудник
            if (userRole == AccessUser.Roles.Employee &&
                Task.Status.Id == (int)StatusModel.TaskStatuses.Created)
            {
                StartWorkBtn.Visibility = Visibility.Visible;
                buttons.Add(StartWorkBtn);
            }


            //Обратная к BackTaskBtn. Отменить возврат задачи сотруднику
            if ((userRole == AccessUser.Roles.Admin || userRole == AccessUser.Roles.ProjectAdministrator) &&
               Task.Status.Id == (int)StatusModel.TaskStatuses.CancelByAdmin)
            {
                ReverseBackTaskBtn.Visibility = Visibility.Visible;
                buttons.Add(BackTaskBtn);
            }
            //Обратная CloseTaskBtn. Открыть задачу, которая была закрыта раннее
            if ((userRole == AccessUser.Roles.Admin || userRole == AccessUser.Roles.ProjectAdministrator) &&
                Task.Status.Id == (int)StatusModel.TaskStatuses.Closed)
            {
                ReverseCloseTaskBtn.Visibility = Visibility.Visible;
                buttons.Add(CloseTaskBtn);
            }
            //Обратная SendTaskBtn. Сотрудник может отменить возможность отправки задачи на проверку.
            if (userRole == AccessUser.Roles.Employee &&
                Task.Status.Id == (int)StatusModel.TaskStatuses.Checking)
            {
                ReverseSendTaskBtn.Visibility = Visibility.Visible;
                buttons.Add(SendTaskBtn);
            }


            int row = 0;
            int column = 0;
            //Предупреждение: Следите за количеством строк в Grid
            foreach (var button in buttons)
            {
                if (column == ButtonsGrid.ColumnDefinitions.Count - 1)
                {
                    row++;
                    column = 0;
                }
                button.SetValue(Grid.ColumnProperty, column++);
                button.SetValue(Grid.RowProperty, row);
            }
        }

        private async void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            bool access = await ProjectAdministratorService.AccessEditProject(ProjectsPageService.ProjectId) || AccessUser.CheckAccess(AccessUser.Roles.Admin);
            if (!access)
            {
                AccessUser.Message(AccessUser.Access.Forbidden, AccessUser.Roles.Admin);
                return;
            }
            ProjectsPageService.ProjectPage.EditorControlGrid.Children.Clear();
            ProjectsPageService.ProjectPage.EditorControlGrid.Children.Add(new UserControls.TaskEditControl(Task));
        }


        private async void SendTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            HistoryChangeStatusTask historyChangeStatusTask = new HistoryChangeStatusTask()
            {
                TaskId = Task.Id,
                StatusId = (int)StatusModel.TaskStatuses.Checking,
            };
            await DbService.AddEntity(historyChangeStatusTask);
            if (!DbService.SaveChangeError)
                MessageBox.Show(@"Задание помечено как ""Отправлено на проверку""");
            else
                MessageBox.Show("Ошибка при изменении статуса задачи");
            ProjectsPageService.FillTasksInPage(UserService.GetUser().Id);
            ProjectsPageService.ProjectPage.EditorControlGrid.Children.Clear();
        }

        private async void CloseTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            HistoryChangeStatusTask historyChangeStatusTask = new HistoryChangeStatusTask()
            {
                TaskId = Task.Id,
                StatusId = (int)StatusModel.TaskStatuses.Closed,
            };
            await DbService.AddEntity(historyChangeStatusTask);
            if (!DbService.SaveChangeError)
                MessageBox.Show(@"Задание помечено как ""Закрыто""");
            else
                MessageBox.Show("Ошибка при изменении статуса задачи");
            ProjectsPageService.FillTasksInPage(UserService.GetUser().Id);
            ProjectsPageService.ProjectPage.EditorControlGrid.Children.Clear();
        }

        private async void BackTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            HistoryChangeStatusTask historyChangeStatusTask = new HistoryChangeStatusTask()
            {
                TaskId = Task.Id,
                StatusId = (int)StatusModel.TaskStatuses.CancelByAdmin,
            };
            await DbService.AddEntity(historyChangeStatusTask);
            if (!DbService.SaveChangeError)
                MessageBox.Show(@"Задание помечено как ""Возвращено руководителем""");
            else
                MessageBox.Show("Ошибка при изменении статуса задачи");
            ProjectsPageService.FillTasksInPage(UserService.GetUser().Id);
            ProjectsPageService.ProjectPage.EditorControlGrid.Children.Clear();
        }

        private async void StartWorkBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите приступить к данной задаче? Отменить действие невозможно", "Предупреждение", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes)
                return;
            Task.StartDate = DateTime.Now;
            await DbService.UpdateEntity(Task);
            HistoryChangeStatusTask historyChangeStatusTask = new()
            {
                TaskId = Task.Id,
                StatusId = (int)StatusModel.TaskStatuses.Work,
            };
            await DbService.AddEntity(historyChangeStatusTask);
            if (!DbService.SaveChangeError)
                MessageBox.Show(@"Задание помечено как ""В работе""");
            else
                MessageBox.Show("Ошибка при изменении статуса задачи");
            ProjectsPageService.FillTasksInPage(UserService.GetUser().Id);
            ProjectsPageService.ProjectPage.EditorControlGrid.Children.Clear();
        }

        private async void ReverseSendTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            var status = await DbService.GetPreLastStatusTask(Task);
            if (status == null)
                throw new Exception("В Бд отсутсвутет предпоследний статус задачи. Такое возможно?");
            HistoryChangeStatusTask historyChangeStatusTask = new()
            {
                TaskId = Task.Id,
                StatusId = status.Id,
            };
            await DbService.AddEntity(historyChangeStatusTask);
            if (!DbService.SaveChangeError)
                MessageBox.Show(@"Отправка задания на проверку отменена");
            else
                MessageBox.Show("Ошибка при изменении статуса задачи");
            ProjectsPageService.FillTasksInPage(UserService.GetUser().Id);
            ProjectsPageService.ProjectPage.EditorControlGrid.Children.Clear();
        }

        private async void ReverseCloseTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            var status = await DbService.GetPreLastStatusTask(Task);
            if (status == null)
                MessageBox.Show("Задача первоначально была закрыта, действие над данной задачей не представляет возможным");
            HistoryChangeStatusTask historyChangeStatusTask = new HistoryChangeStatusTask()
            {
                TaskId = Task.Id,
                StatusId = status.Id,
            };
            await DbService.AddEntity(historyChangeStatusTask);
            if (!DbService.SaveChangeError)
                MessageBox.Show(@"Статус задачи изменен");
            else
                MessageBox.Show("Ошибка при изменении статуса задачи");
            ProjectsPageService.FillTasksInPage(ProjectsPageService.ProjectId);
            ProjectsPageService.ProjectPage.EditorControlGrid.Children.Clear();
        }


        private async void ReverseBackTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            var status = await DbService.GetPreLastStatusTask(Task);
            HistoryChangeStatusTask historyChangeStatusTask = new HistoryChangeStatusTask()
            {
                TaskId = Task.Id,
                StatusId = status.Id,
            };
            await DbService.AddEntity(historyChangeStatusTask);
            if (!DbService.SaveChangeError)
                MessageBox.Show(@"Статус задачи изменен");
            else
                MessageBox.Show("Ошибка при изменении статуса задачи");
            ProjectsPageService.FillTasksInPage(ProjectsPageService.ProjectId);
            ProjectsPageService.ProjectPage.EditorControlGrid.Children.Clear();
        }
    }
}
