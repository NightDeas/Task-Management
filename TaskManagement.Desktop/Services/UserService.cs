using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Desktop.Services
{
    public static class UserService
    {
        private static Models.User User;

        public static Models.User GetUser()
        {
            return User;
        }

        public static void SetUser(Models.User user)
        {
            User = user;
        }
        public static void ResetUser()
        {
            User = null;
        }

        

        

        public static async Task<bool> Auth(string login, string password)
        {
            User = await DbService.GetUserAsync(login, password);
            if (User == null)
                return false;
            return true;
        }
    }
}

