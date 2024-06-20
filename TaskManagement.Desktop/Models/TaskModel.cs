using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DataBase.Entities;
using Task = TaskManagement.DataBase.Entities.Task;

namespace TaskManagement.Desktop.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public bool Deleted { get; set; }

		public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public DateTime Deadline { get; set; }
        public int UserId { get;set; } 
        public int ProjectId { get; set; }
        public User User { get; set; }

        public Status Status { get; set; }

        public static TaskModel ToModel(DataBase.Entities.Task task)
        {
            return new TaskModel()
            {
                Id = task.Id,
                Created = task.Created,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Deadline = task.Deadline,
                Name = task.Name,
                Description = task.Description,
                User = new User().ToModel(task.User),
                UserId = task.UserId
            };
        }

        public static TaskModel ToModel(DataBase.Entities.HistoryChangeStatusTask historyChangeStatusTask)
        {
            return new TaskModel()
            {
                Id = historyChangeStatusTask.TaskId,
                Created = historyChangeStatusTask.Task.Created,
                StartDate = historyChangeStatusTask.Task.StartDate,
                EndDate = historyChangeStatusTask.Task.EndDate,
                Deadline = historyChangeStatusTask.Task.Deadline,
                Name = historyChangeStatusTask.Task.Name,
                Description = historyChangeStatusTask.Task.Description,
                User = new User().ToModel(historyChangeStatusTask.Task.User),
                Status = historyChangeStatusTask.Status
            };
        }

        public DataBase.Entities.Task ToDbModel()
        {
            return new Task()
            {
                Id = this.Id,
                Created = this.Created,
                Updated = this.Updated,
                Deleted = this.Deleted,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                Deadline = this.Deadline,
                Name = this.Name,
                Description = this.Description,
                UserId = this.UserId,
                ProjectId = this.ProjectId,
            };

        }
    }
}
