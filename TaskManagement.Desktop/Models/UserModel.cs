using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DataBase.Entities;

namespace TaskManagement.Desktop.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string LastName { get;set; }
        public string FirstName { get;set; }
        public string? Patronymic { get;set; }
        public Role Role { get;set; }
        public string FullName { get => $"{LastName} {FirstName} {Patronymic}"; }
        public string ShortName { get => Patronymic == null ? $"{LastName}. {FirstName.First()}" : $"{LastName}. {FirstName.First()}. {Patronymic.First()}"; }

      
        public UserModel ToModel(DataBase.Entities.User user)
        {
            if (user == null)
                return null;
            return new UserModel()
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Patronymic = user.Patronymic,
                Role = user.Role,
            };
        }

        public List<UserModel> ToModel(List<DataBase.Entities.User> users)
        {
            if (users == null)
                return null;
            var usersModels = users.Select(ToModel).ToList();
            return usersModels;
        }
    }
}
