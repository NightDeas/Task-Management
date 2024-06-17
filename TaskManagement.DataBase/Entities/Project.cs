using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.DataBase.Entities
{
    public class Project
    {
        public int Id { get; init; }
        public required string Name { get; set; }

        public bool IsDeleted { get; set; } = false;
        
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
