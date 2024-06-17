using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.DataBase.Entities
{
    public class User
    {
        public int Id { get; init; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public string? Patronymic { get; set; }
        public required int RoleId { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
        public virtual Role Role { get; set; }
    }
}
