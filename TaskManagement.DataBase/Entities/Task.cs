using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.DataBase.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool Deleted { get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
        public DateTime Deadline { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<HistoryChangeStatusTask> HistoryChangeStatusTask { get; set; }
	}
}
