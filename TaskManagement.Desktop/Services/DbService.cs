using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DataBase.Contexts;
using TaskManagement.DataBase.Entities;
using TaskManagement.DataBase.Migrations;
using TaskManagement.Desktop.Models;
using TaskManagement.Desktop.UserControls;

namespace TaskManagement.Desktop.Services
{
    public static class DbService
    {
        private static DataBase.Contexts.Context _context = new();



        /// <summary>
        /// Фактического удаления не происходит, меняем IsDeleted на true
        /// </summary>
        /// <param name="model">Модель проекта</param>
        /// <returns>Успешное/не успешное удаление</returns>
        public static async Task<bool> DeleteEntity(ProjectModel model)
        {
            Project project = ProjectModel.ToDbModel(model);
            project.IsDeleted = true;
            _context.Entry(project).State = EntityState.Modified;
            return await SaveChangedAsync();
        }

        public static async Task<bool> UpdateEntity(ProjectModel model)
        {
            Project project = ProjectModel.ToDbModel(model);
            _context.Entry(project).State = EntityState.Modified;
            return await SaveChangedAsync();
        }

        public static async Task<bool> AddEntity(ProjectModel model)
        {
            Project project = ProjectModel.ToDbModel(model);
            _context.Entry(project).State = EntityState.Added;
            return await SaveChangedAsync();
        }

        public static async Task<bool> SaveChangedAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<Models.User> GetUserAsync(string login, string password)
        {
            var user = await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
            return new Models.User().ToModel(user);
        }

        public static async Task<List<Models.User>> GetUsersAsync(int roleId)
        {
            var users = await _context.Users
                .Where(x => x.RoleId == roleId)
                .ToListAsync();
            var usersModels = new Models.User().ToModel(users);
            return usersModels;
        }

        public static async Task<bool> CheckAccessEditTaskAsync(int projectId)
        {
            int? projectAdministratorId = (await _context.Users.FirstOrDefaultAsync(x => x.Id == UserService.GetUser().Id && x.RoleId == 2))?.Id;
            if (projectAdministratorId == null)
                return false;
            if (await _context.ProjectProjectAdministrators.AnyAsync(x => x.ProjectAdministratorId == projectId && x.ProjectAdministratorId == projectAdministratorId))
                return true;
            return false;
        }



        public static async Task<List<Project>> GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
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
                .Include(x => x.Project)
               .ToListAsync();
        }

        public static async Task<List<DataBase.Entities.Task>> GetTasks()
        {
            return await _context.Tasks
                .ToListAsync();
        }

        public static async Task<List<DataBase.Entities.HistoryChangeStatusTask>> GetHistoryChangeStatusTask()
        {
            return await _context.HistoryChangeStatusTask
                .Include(x => x.Task)
                .ToListAsync();
        }


        public static async Task<List<DataBase.Entities.HistoryChangeStatusTask>> GetHistoryChangeStatusTaskAsync(int projectId)
        {
            return await _context.HistoryChangeStatusTask
                .Include(x => x.Task)
                .ThenInclude(x => x.User)
                .Include(x => x.Status)
                .Where(x => x.Task.ProjectId == projectId)
                .ToListAsync();
        }
        public static async Task<List<DataBase.Entities.HistoryChangeStatusTask>> GetHistoryChangeStatusTaskAsync(int projectId, int userId)
        {
            return await _context.HistoryChangeStatusTask
                .Include(x => x.Task)
                .Include(x => x.Status)
                .Where(x => x.Task.UserId == userId && x.Task.ProjectId == projectId)
                .ToListAsync();
        }

        public static async Task<DataBase.Entities.Status> GetStatusAsync(int statusId)
        {
            return await _context.Statuses.FirstOrDefaultAsync(x => x.Id == statusId);
        }
    }
}
