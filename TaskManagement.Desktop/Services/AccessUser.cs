using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskManagement.DataBase.Entities;

namespace TaskManagement.Desktop.Services
{
    public static class AccessUser
    {

        public enum Roles
        {
            Admin = 1,
            ProjectAdministrator,
            Employee
        }
        public enum Access
        {
            Allowed = 1,
            Forbidden
        }
        public static bool CheckAccess(Roles RequiredRole)
        {
            if (UserService.GetUser().Role.Id == (int)RequiredRole)
            {
                Message(Access.Allowed);
                return true;
            }
            else
            {
                Message(Access.Forbidden, RequiredRole);
                return false;
            }
        }


        public static void Message(Access typeAccess)
        {
            switch (typeAccess)
            {
                case Access.Allowed:
                    break;
                case Access.Forbidden:
                    MessageBox.Show($"Недостаточно прав доступа.",
                                      "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                default:
                    break;
            }
        }

        public static void Message(Access typeAccess, Roles RequiredRole)
        {
            switch (typeAccess)
            {
                case Access.Allowed:
                    break;
                case Access.Forbidden:
                    MessageBox.Show($"Недостаточно прав доступа. Требуется права уровня {RequiredRole}",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                default:
                    break;
            }
        }
    }
}
