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

        public static Roles GetRoleUser()
        {
            return (Roles)UserService.GetUser().Role.Id;
        }
        public static bool CheckAccess(Roles RequiredRole)
        {
            if (GetRoleUser() == RequiredRole)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

		public static bool CheckAccess(List<Roles> RequiredRoles)
		{
            if (RequiredRoles.Contains(GetRoleUser()))
			{
				Message(Access.Allowed);
				return true;
			}
			else
			{
				Message(Access.Forbidden, RequiredRoles[0]);
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
