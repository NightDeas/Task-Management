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
        private static List<Models.User> projectsAdministrators = new();

        public static List<User> ProjectsAdministrators { get => projectsAdministrators; }

        public void AddUser(Models.User user)
        {
            if (!CheckAvialiability(user))
                ProjectsAdministrators.Add(user);
        }

        public void DeleteUser(Models.User user)
        {
            ProjectsAdministrators.Remove(user);
        }

        private bool CheckAvialiability(Models.User user)
        {
            return projectsAdministrators.Any(x=> x.Id == user.Id);
        }
    }
}
