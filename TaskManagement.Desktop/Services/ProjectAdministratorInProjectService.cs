using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Desktop.Models;

namespace TaskManagement.Desktop.Services
{
	public class ProjectAdministratorInProjectService
	{
		private static List<Models.UserModel> projectsAdministrators = new();

		public static List<UserModel> ProjectsAdministrators { get => projectsAdministrators; }

		public void AddUser(Models.UserModel user)
		{
			if (!CheckAvialiability(user))
				ProjectsAdministrators.Add(user);
		}

		public void ResetList()
		{
			ProjectsAdministrators.Clear();
		}

		public void DeleteUser(Models.UserModel user)
		{
			ProjectsAdministrators.Remove(user);
		}

		private bool CheckAvialiability(Models.UserModel user)
		{
			return projectsAdministrators.Any(x => x.Id == user.Id);
		}

		public async Task AddListEntitiesInBd(int projectId)
		{
			await DbService.AddEntity(projectsAdministrators, projectId);
		}

		public async Task UpdateListEntitiesInBd(int projectId)
		{
			await DbService.UpdateListProjectProjectAdministrators(projectsAdministrators, projectId);
		}
	}
}
