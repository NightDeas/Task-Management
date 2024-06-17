using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagement.Desktop.Services
{
    public static class ProjectAdministratorService
    {
        public static async Task<bool> AccessEditProject(int projectId)
        {
            if (!CheckRole())
                return false;
            bool access = await DbService.CheckAccessEditTaskAsync(projectId);
            if (!access) 
                return false;
            return true;
          
        }

        public static bool CheckRole()
        {
            if (UserService.GetUser().Role.Id == 2)
                return true;
            return false;
        }
    }
}
