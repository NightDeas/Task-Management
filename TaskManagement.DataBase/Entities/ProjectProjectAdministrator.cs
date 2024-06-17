using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.DataBase.Entities
{
    public class ProjectProjectAdministrator
    {
        public int Id { get;set; }
        public required int ProjectId { get;set; }   
        public required int ProjectAdministratorId { get;set;}
        public virtual Project Project { get; set; }
        public virtual User ProjectAdministrator { get; set; }
    }
}
