using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskManagement.DataBase.Contexts;
using TaskManagement.DataBase.Entities;
using TaskManagement.DataBase.Migrations;
using TaskManagement.Desktop.Models;
using TaskManagement.Desktop.UserControls;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Desktop.Services
{
    public static class DbService
    {
        private static DataBase.Contexts.Context _context = new();
        private static bool saveChangeError;

        public static bool SaveChangeError { get => saveChangeError; set => saveChangeError = value; }




        private static async Task<bool> CanConntect()
        {
            Debug.WriteLine("Проверка соединения с БД");
            bool canConnect = false;
            int count = 1;
            Task.Factory.StartNew(async () =>
            {
                while (!canConnect)
                {
                    if (count == 4)
                        break;
                    canConnect = await _context.Database.CanConnectAsync();
                    Debug.WriteLine($"Попытка соединения с БД #{count} - {canConnect}");
                    if (!canConnect)
                    {
                        await Task.Delay(200);
                        count++;
                    }
                }
            });
            return canConnect;
        }

        /// <summary>
        /// Добавление сущности в ProjectProjectAdministrator
        /// </summary>
        /// <param name="users">Список руководителей</param>
        /// <param name="projectId">Id проекта</param>
        /// <returns>true - если сущности добавились без ошибок, false - сущности не бьыли добавлены</returns>
        public static async Task AddEntity(List<Models.UserModel> users, int projectId)
        {

            DataBase.Entities.ProjectProjectAdministrator projectProjectAdministrator;
            foreach (var user in users)
            {
                projectProjectAdministrator = new()
                {
                    ProjectId = projectId,
                    ProjectAdministratorId = user.Id,
                };
                _context.Entry(projectProjectAdministrator).State = EntityState.Added;
            }

            await SaveChangedAsync();

        }

        public static async Task AddEntity(HistoryChangeStatusTask historyChangeStatusTask)
        {

            DataBase.Entities.HistoryChangeStatusTask historyChangeStatus = historyChangeStatusTask;
            _context.Entry(historyChangeStatus).State = EntityState.Added;

            await SaveChangedAsync();

        }

        public static async Task DeleteEntity(ProjectModel model)
        {

            Project project = ProjectModel.ToDbModel(model);
            project.IsDeleted = true;
            _context.Entry(project).State = EntityState.Modified;
            await SaveChangedAsync();

        }

        public static async Task UpdateEntity(ProjectModel model)
        {

            Project project = ProjectModel.ToDbModel(model);
            _context.Entry(project).State = EntityState.Modified;
            await SaveChangedAsync();

        }

        public static async Task<int> AddEntity(ProjectModel model)
        {

            Project project = ProjectModel.ToDbModel(model);
            _context.Entry(project).State = EntityState.Added;
            await SaveChangedAsync();

            return project.Id;
        }

        public static async Task SaveChangedAsync()
        {

            try
            {
                await _context.SaveChangesAsync();
                SaveChangeError = false;
            }
            catch (Exception ex)
            {
                SaveChangeError = true;
                MessageBox.Show($"{ex.Message}",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

            }

        }


        public static async Task<Models.UserModel> GetUserAsync(string login, string password)
        {
            Context context = new();
			var user = await context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Login == login && x.Password == password);

            return new Models.UserModel().ToModel(user);
        }


		public static async Task<List<DataBase.Entities.User>> GetUsersAsync()
		{
			Context context = new();

			var users = await _context.Users
                .AsNoTracking()
				.ToListAsync();

			return users;
		}
		public static async Task<List<DataBase.Entities.User>> GetUsersAsync(AccessUser.Roles role)
        {

            //var users = await _context.Users
            //	.Where(x => x.RoleId == (int)role)
            //	.ToListAsync();
            Context context = new();


			var users = await _context.Users
				.AsNoTracking()
				.Where(x => x.RoleId == (int)role)
                .ToListAsync();

            return users;
        }

        public static async Task<bool> CheckAccessEditTaskAsync(int projectId)
        {

            int? projectAdministratorId = (await _context.Users.FirstOrDefaultAsync(x => x.Id == UserService.GetUser().Id && x.RoleId == 2))?.Id;

            if (projectAdministratorId == null)
                return false;
            if (await _context.ProjectProjectAdministrators.AnyAsync(x => x.ProjectId == projectId && x.ProjectAdministratorId == projectAdministratorId))
                return true;
            return false;

        }


        /// <summary>
        /// Получить проекты, которые не были удалены.
        /// Проект считается удаленным, есть isDeleted = true
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Project>> GetProjectsAsync()
        {
            switch (AccessUser.GetRoleUser())
            {
                case AccessUser.Roles.Admin:
                    return await _context.Projects
                               .Where(x => x.IsDeleted == false)
                               .ToListAsync();
                case AccessUser.Roles.ProjectAdministrator:
                    return await _context.ProjectProjectAdministrators
                              .Include(x => x.Project)
                              .Where(x => x.ProjectAdministratorId == UserService.GetUser().Id)
                              .Select(x => x.Project)
                              .ToListAsync();
                case AccessUser.Roles.Employee:
                    return await _context.Projects
                        .Include(x => x.Tasks)
                        .Where(x => x.IsDeleted == false && x.Tasks.Any(x => x.UserId == UserService.GetUser().Id))
                        .ToListAsync();
                default:
                    throw new Exception($"Нету обработки для роли: {AccessUser.GetRoleUser()}");
            }
        }

        public static async Task<List<Project>> GetProjectsAsync(string searchText)
        {
            switch (AccessUser.GetRoleUser())
            {
                case AccessUser.Roles.Admin:
                    return await _context.Projects
                               .Where(x => (x.IsDeleted == false) &&
                               x.Name.Contains(searchText))
                               .ToListAsync();
                case AccessUser.Roles.ProjectAdministrator:
                    return await _context.ProjectProjectAdministrators
                              .Include(x => x.Project)
                              .Where(x => (x.ProjectAdministratorId == UserService.GetUser().Id) &&
                              (x.Project.Name.Contains(searchText)))
                              .Select(x => x.Project)
                              .ToListAsync();
                case AccessUser.Roles.Employee:
                    return await _context.Projects
                        .Include(x => x.Tasks)
                        .Where(x => x.IsDeleted == false &&
                        x.Tasks.Any(x => x.UserId == UserService.GetUser().Id) &&
                        x.Name.Contains(searchText))
                        .ToListAsync();
                default:
                    throw new Exception($"Нету обработки для роли: {AccessUser.GetRoleUser()}");
            }
        }

        public static async Task<List<Project>> GetProjectsAsync(int userId)
        {

            List<Project> projects = new();
            var tasks = await GetTasksThenProject();
            foreach (var task in tasks)
            {
                if (task.UserId == userId && !(projects.Any(x => x.Id == task.ProjectId)))
                    projects.Add(task.Project);
            }

            return projects;
        }

        public static async Task<List<Project>> GetProjectsAsync(int userId, int roleId)
        {

            if (roleId == 2)
                return await GetProjectForAdministratorsAsync(userId);
            List<Project> projects = new();
            var tasks = await GetTasksThenProject();
            foreach (var task in tasks)
            {
                if (task.UserId == userId)
                    projects.Add(task.Project);
            }

            return projects;
        }



        public static async Task<List<DataBase.Entities.Project>> GetProjectForAdministratorsAsync(int userId)
        {


            return await _context.ProjectProjectAdministrators
               .Include(x => x.Project)
               .Where(x => x.ProjectAdministratorId == userId)
               .Select(x => x.Project)
               .ToListAsync();
        }

        public static async Task<List<DataBase.Entities.Task>> GetTasksThenProject()
        {


            return await _context.Tasks
                .AsNoTracking()
                .Include(x => x.Project)
               .ToListAsync();
        }

        public static async Task<List<DataBase.Entities.Task>> GetTasks()
        {


            return await _context.Tasks
                .AsNoTracking()
                .ToListAsync();
        }

        public static async Task<List<DataBase.Entities.HistoryChangeStatusTask>> GetHistoryChangeStatusTask()
        {


            return await _context.HistoryChangeStatusTask
                .AsNoTracking()
                .Include(x => x.Task)
                .GroupBy(x => x.TaskId)
                .Select(g => g.OrderBy(x => x.Id).Last())
                .ToListAsync();
        }

        public static async Task<List<DataBase.Entities.HistoryChangeStatusTask>> GetHistoryChangeStatusTaskAsync(int projectId)
        {

            var historyChangeStatusTasks = await _context.HistoryChangeStatusTask
                .AsNoTracking()
                .Include(x => x.Task)
                .ThenInclude(x => x.User)
                .Include(x => x.Status)
                .Where(x => x.Task.ProjectId == projectId)
                .GroupBy(x => x.TaskId)
                .Select(g => g.OrderBy(x => x.Id).Last())
                .ToListAsync();

            return historyChangeStatusTasks;
        }
        public static async Task<List<DataBase.Entities.HistoryChangeStatusTask>> GetHistoryChangeStatusTaskAsync(int projectId, int userId)
        {


            return await _context.HistoryChangeStatusTask
                .AsNoTracking()
                .Include(x => x.Task)
                .ThenInclude(x => x.User)
                .Include(x => x.Status)
                .Where(x => x.Task.UserId == userId && x.Task.ProjectId == projectId)
                .GroupBy(x => x.TaskId)
                .Select(g => g.OrderBy(x => x.Id).Last())
                .ToListAsync();
        }

        public static async Task<List<HistoryChangeStatusTask>> GetHistoryChangeStatusTaskAsync(int projectId, string searchText)
        {
            if (!await CanConntect())
                return new();
            return await _context.HistoryChangeStatusTask
              .AsNoTracking()
              .Include(x => x.Task)
              .ThenInclude(x => x.User)
              .Include(x => x.Status)
              .Where(x => x.Task.ProjectId == projectId &&
              (x.Task.Name.Contains(searchText) ||
              x.Task.StartDate.ToString().Contains(searchText) ||
              x.Task.EndDate.ToString().Contains(searchText) ||
              x.Task.Deadline.ToString().Contains(searchText) ||
              x.Task.Description.Contains(searchText) ||
              x.Task.Updated.ToString().Contains(searchText) ||
              x.Task.User.LastName.Contains(searchText) ||
			  x.Task.User.FirstName.Contains(searchText) ||
			  x.Task.User.Patronymic.Contains(searchText)))
              .GroupBy(x => x.TaskId)
              .Select(g => g.OrderBy(x => x.Id).Last())
              .ToListAsync();
        }
        public static async Task<DataBase.Entities.Status> GetStatusAsync(int statusId)
        {


            return await _context.Statuses.FirstOrDefaultAsync(x => x.Id == statusId);
        }

        public static async Task UpdateListProjectProjectAdministrators(List<Models.UserModel> projectsAdministrators, int projectId)
        {

            List<DataBase.Entities.ProjectProjectAdministrator> projectadmins =
                _context.ProjectProjectAdministrators
                .Where(x => x.ProjectId == projectId)
                .ToList();
            foreach (var projectAdmin in projectadmins)
            {
                if (!projectsAdministrators.Any(x => x.Id == projectAdmin.Id))
                {
                    _context.Entry(projectAdmin).State = EntityState.Deleted;
                    continue;
                }
            }
            foreach (var projectAdmin in projectsAdministrators)
            {
                if (!projectadmins.Any(x => x.ProjectId == projectAdmin.Id))
                    _context.Entry(
                    new DataBase.Entities.ProjectProjectAdministrator()
                    {
                        ProjectAdministratorId = projectAdmin.Id,
                        ProjectId = projectId
                    })
                    .State = EntityState.Added;
            }
            await SaveChangedAsync();

        }

        public static async Task<List<DataBase.Entities.User>> GetProjectAdminstratorInProject(int projectId)
        {
            if (!await CanConntect())
                return new();
            var projectadmins = await _context.ProjectProjectAdministrators
            .Include(x => x.ProjectAdministrator)
            .Where(x => x.ProjectId == projectId)
            .Select(x => x.ProjectAdministrator)
            .ToListAsync();
            return projectadmins;
        }

        public static async Task<int> AddEntity(TaskModel taskModel)
        {

            DataBase.Entities.Task task = taskModel.ToDbModel();
            _context.Entry(task).State = EntityState.Added;
            await SaveChangedAsync();
            _context.Entry(task).State = EntityState.Detached;

            return task.Id;
        }

        public static async Task UpdateEntity(TaskModel taskModel)
        {

            DataBase.Entities.Task task = taskModel.ToDbModel();
            task.Updated = DateTime.Now;
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            _context.Entry(task).State = EntityState.Detached;

        }

        /// <summary
        /// </summary>
        /// <param name="model">Модель задачи</param>
        public static async Task DeleteEntity(TaskModel model)
        {

            DataBase.Entities.Task task = model.ToDbModel();
            task.Deleted = true;
            _context.Entry(task).State = EntityState.Modified;
            await SaveChangedAsync();

        }

        public static async Task<StatusModel> GetPreLastStatusTask(TaskModel model)
        {

            Debug.WriteLine("DbService: возврат из GetPreLastStatusTask");
            var status = await _context.HistoryChangeStatusTask
                .Include(x => x.Status)
                .Where(x => x.TaskId == model.Id)
                .OrderByDescending(x => x.Id)
                .Select(g => g.Status)
                .Skip(1)
                .FirstOrDefaultAsync();
            return new StatusModel().ToModel(status);

        }

        public static async Task<int> GetCountCompletedTasksByUserAsync(int userId)
        {
            Context context = new();
            //if (!await CanConntect())
            //    return 0;
            return await context.HistoryChangeStatusTask
                .AsNoTracking()
                .Include(x => x.Task)
                .Where(x => x.Task.UserId == userId && x.StatusId == (int)Models.StatusModel.TaskStatuses.Closed)
                .CountAsync();
        }

		public static async Task<int> GetCountNotCompletedTasksByUserAsync(int userId)
		{
            Context context = new();
			//if (!await CanConntect())
			//	return 0;
			return await context.HistoryChangeStatusTask
                .AsNoTracking()
				.Include(x => x.Task)
				.Where(x => x.Task.UserId == userId && x.StatusId != (int)Models.StatusModel.TaskStatuses.Closed)
				.CountAsync();
		}



	}
}
