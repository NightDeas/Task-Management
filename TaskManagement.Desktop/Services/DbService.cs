using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.VisualBasic.ApplicationServices;
using System;
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

		/// <summary>
		/// Добавление сущности в ProjectProjectAdministrator
		/// </summary>
		/// <param name="users">Список руководителей</param>
		/// <param name="projectId">Id проекта</param>
		/// <returns>true - если сущности добавились без ошибок, false - сущности не бьыли добавлены</returns>
		public static async Task AddEntity(List<Models.User> users, int projectId)
		{
			Debug.WriteLine("DbService: Вход AddEntity");
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
			Debug.WriteLine("DbService: выход AddEntity");
		}

		public static async Task AddEntity(HistoryChangeStatusTask historyChangeStatusTask)
		{
			Debug.WriteLine("DbService: Вход AddEntity");
			DataBase.Entities.HistoryChangeStatusTask historyChangeStatus = historyChangeStatusTask;
			_context.Entry(historyChangeStatus).State = EntityState.Added;

			await SaveChangedAsync();
			Debug.WriteLine("DbService: выход AddEntity");
		}


		/// <summary>
		/// Фактического удаления не происходит, меняем IsDeleted на true
		/// </summary>
		/// <param name="model">Модель проекта</param>
		/// <returns>Успешное/не успешное удаление</returns>
		public static async Task DeleteEntity(ProjectModel model)
		{
			Debug.WriteLine("DbService: Вход ToDbModel");
			Project project = ProjectModel.ToDbModel(model);
			project.IsDeleted = true;
			_context.Entry(project).State = EntityState.Modified;
			await SaveChangedAsync();
			Debug.WriteLine("DbService: выход ToDbModel");
		}

		public static async Task UpdateEntity(ProjectModel model)
		{
			Debug.WriteLine("DbService: Вход UpdateEntity");
			Project project = ProjectModel.ToDbModel(model);
			_context.Entry(project).State = EntityState.Modified;
			await SaveChangedAsync();
			Debug.WriteLine("DbService: Выход UpdateEntity");
		}

		public static async Task<int> AddEntity(ProjectModel model)
		{
			Debug.WriteLine("DbService: Вход AddEntity");
			Project project = ProjectModel.ToDbModel(model);
			_context.Entry(project).State = EntityState.Added;
			await SaveChangedAsync();
			Debug.WriteLine("DbService: Выход AddEntity");
			return project.Id;
		}

		public static async Task SaveChangedAsync()
		{
			Debug.WriteLine("DbService: Вход SaveChangedAsync");
			try
			{
				await _context.SaveChangesAsync();
				SaveChangeError = false;
				Debug.WriteLine("DbService: Выход SaveChangedAsync(Успешно)");
			}
			catch (Exception ex)
			{
				SaveChangeError = true;
				MessageBox.Show($"{ex.Message}",
					"Ошибка",
					MessageBoxButton.OK,
					MessageBoxImage.Error);
				Debug.WriteLine("DbService: Выход SaveChangedAsync(Ошибка!)");
			}

		}


		public static async Task<Models.User> GetUserAsync(string login, string password)
		{
			Debug.WriteLine("DbService: Вход GetUserAsync");
			var user = await _context.Users
				.Include(x => x.Role)
				.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
			Debug.WriteLine("DbService: Выход GetUserAsync");
			return new Models.User().ToModel(user);
		}

		public static async Task<List<Models.User>> GetUsersAsync(AccessUser.Roles role)
		{
			Debug.WriteLine("DbService: Вход GetUserAsync");
			//var users = await _context.Users
			//	.Where(x => x.RoleId == (int)role)
			//	.ToListAsync();
			Context context = new(); // для избежания исключения


			var users = await context.Users
				.Where(x => x.RoleId == (int)role)
				.ToListAsync();
			var usersModels = new Models.User().ToModel(users);
			Debug.WriteLine("DbService: Выход GetUserAsync");
			return usersModels;
		}

		public static async Task<bool> CheckAccessEditTaskAsync(int projectId)
		{
			Debug.WriteLine("DbService: Вход CheckAccessEditTaskAsync");
			int? projectAdministratorId = (await _context.Users.FirstOrDefaultAsync(x => x.Id == UserService.GetUser().Id && x.RoleId == 2))?.Id;
			Debug.WriteLine("DbService: Выход CheckAccessEditTaskAsync");
			if (projectAdministratorId == null)
				return false;
			if (await _context.ProjectProjectAdministrators.AnyAsync(x => x.ProjectAdministratorId == projectId && x.ProjectAdministratorId == projectAdministratorId))
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
			Debug.WriteLine("DbService: Вход GetProjectsAsync");
			Debug.WriteLine("DbService: Выход GetProjectsAsync");
			return await _context.Projects
				.Where(x=> x.IsDeleted == false)
				.ToListAsync();
		}

		public static async Task<List<Project>> GetProjectsAsync(int userId)
		{
			Debug.WriteLine("DbService: Вход GetProjectsAsync");
			List<Project> projects = new();
			var tasks = await GetTasksThenProject();
			foreach (var task in tasks)
			{
				if (task.UserId == userId && !(projects.Any(x => x.Id == task.ProjectId)))
					projects.Add(task.Project);
			}
			Debug.WriteLine("DbService: Выход GetProjectsAsync");
			return projects;
		}

		public static async Task<List<Project>> GetProjectsAsync(int userId, int roleId)
		{
			Debug.WriteLine("DbService: Вход GetProjectsAsync");
			if (roleId == 2)
				return await GetProjectForAdministratorsAsync(userId);
			List<Project> projects = new();
			var tasks = await GetTasksThenProject();
			foreach (var task in tasks)
			{
				if (task.UserId == userId)
					projects.Add(task.Project);
			}
			Debug.WriteLine("DbService: Выход GetProjectsAsync");
			return projects;
		}



		public static async Task<List<DataBase.Entities.Project>> GetProjectForAdministratorsAsync(int userId)
		{
			Debug.WriteLine("DbService: Вход GetProjectForAdministratorsAsync");
			Debug.WriteLine("DbService: Выход GetProjectForAdministratorsAsync");
			return await _context.ProjectProjectAdministrators
			   .Include(x => x.Project)
			   .Where(x => x.ProjectAdministratorId == userId)
			   .Select(x => x.Project)
			   .ToListAsync();
		}

		public static async Task<List<DataBase.Entities.Task>> GetTasksThenProject()
		{
			Debug.WriteLine("DbService: Вход GetTasksThenProject");
			Debug.WriteLine("DbService: Выход GetTasksThenProject");
			return await _context.Tasks
				.AsNoTracking()
				.Include(x => x.Project)
			   .ToListAsync();
		}

		public static async Task<List<DataBase.Entities.Task>> GetTasks()
		{
			Debug.WriteLine("DbService: Вход GetTasks");
			Debug.WriteLine("DbService: Выход GetTasks");
			return await _context.Tasks
				.AsNoTracking()
				.ToListAsync();
        }

		public static async Task<List<DataBase.Entities.HistoryChangeStatusTask>> GetHistoryChangeStatusTask()
		{
			Debug.WriteLine("DbService: Вход GetHistoryChangeStatusTask");
			Debug.WriteLine("DbService: Выход GetHistoryChangeStatusTask");
			return await _context.HistoryChangeStatusTask
                .AsNoTracking()
                .Include(x => x.Task)
				.ToListAsync();
		}

		public static async Task<List<DataBase.Entities.HistoryChangeStatusTask>> GetHistoryChangeStatusTaskAsync(int projectId)
		{
			Debug.WriteLine("DbService: Вход GetHistoryChangeStatusTaskAsync");
			var historyChangeStatusTasks = await _context.HistoryChangeStatusTask
				.AsNoTracking()
				.Include(x => x.Task)
				.ThenInclude(x => x.User)
				.Include(x => x.Status)
				.Where(x => x.Task.ProjectId == projectId)
				.ToListAsync();
			Debug.WriteLine("DbService: Выход GetHistoryChangeStatusTaskAsync");
			return historyChangeStatusTasks;
		}
		public static async Task<List<DataBase.Entities.HistoryChangeStatusTask>> GetHistoryChangeStatusTaskAsync(int projectId, int userId)
		{
			Debug.WriteLine("DbService: Вход GetHistoryChangeStatusTaskAsync");
			Debug.WriteLine("DbService: Выход GetHistoryChangeStatusTaskAsync");
			return await _context.HistoryChangeStatusTask
				.AsNoTracking()
				.Include(x => x.Task)
                .Include(x => x.Status)
				.Where(x => x.Task.UserId == userId && x.Task.ProjectId == projectId)
				.ToListAsync();
		}

		public static async Task<DataBase.Entities.Status> GetStatusAsync(int statusId)
		{
			Debug.WriteLine("DbService: Вход GetStatusAsync");
			Debug.WriteLine("DbService: Выход GetStatusAsync");
			return await _context.Statuses.FirstOrDefaultAsync(x => x.Id == statusId);
		}

		public static async Task UpdateListProjectProjectAdministrators(List<Models.User> projectsAdministrators, int projectId)
		{
			Debug.WriteLine("DbService: Вход UpdateListProjectProjectAdministrators");
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
			Debug.WriteLine("DbService: Выход UpdateListProjectProjectAdministrators");
		}

		public static async Task<List<DataBase.Entities.User>> GetProjectAdminstratorInProject(int projectId)
		{
			Debug.WriteLine("DbService: Вход GetProjectAdminstratorInProject");
			var projectadmins = await _context.ProjectProjectAdministrators
				.Include(x => x.ProjectAdministrator)
				.Where(x => x.ProjectId == projectId)
				.Select(x => x.ProjectAdministrator)
				.ToListAsync();
			Debug.WriteLine("DbService: Выход GetProjectAdminstratorInProject");
			return projectadmins;
		}

		public static async Task<int> AddEntity(TaskModel taskModel)
		{
			Debug.WriteLine("DbService: Вход AddEntity");
			DataBase.Entities.Task task = taskModel.ToDbModel();
			_context.Entry(task).State = EntityState.Added;
			await SaveChangedAsync();
			Debug.WriteLine("DbService: выход AddEntity");
			return task.Id;
		}

		public static async Task UpdateEntity(TaskModel taskModel)
		{
			Debug.WriteLine("DbService: Вход UpdateEntity");
			DataBase.Entities.Task task = taskModel.ToDbModel();
			_context.Tasks.Update(task);
			await _context.SaveChangesAsync();
			Debug.WriteLine("DbService: Выход UpdateEntity");
		}

		/// <summary>
		/// Фактического удаления не происходит, меняем Deleted на true
		/// </summary>
		/// <param name="model">Модель задачи</param>
		public static async Task DeleteEntity(TaskModel model)
		{
			Debug.WriteLine("DbService: Вход DeleteEntity");
			DataBase.Entities.Task task = model.ToDbModel();
			task.Deleted = true;
			_context.Entry(task).State = EntityState.Modified;
			await SaveChangedAsync();
			Debug.WriteLine("DbService: выход DeleteEntity");
		}
	}
}
