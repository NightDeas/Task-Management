using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DataBase.Entities;

namespace TaskManagement.Desktop.Models
{
    public class TaskModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public DateTime Deadline { get; set; }

        public User User { get; set; }

        public Status Status { get; set; }

        public static TaskModel ToModel(DataBase.Entities.Task task)
        {
            return new TaskModel()
            {
                Created = task.Created,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Deadline = task.Deadline,
                Name = task.Name,
                Description = task.Description,
                User = new User().ToModel(task.User),
            };
        }

        public static TaskModel ToModel(DataBase.Entities.HistoryChangeStatusTask historyChangeStatusTask)
        {
            return new TaskModel()
            {
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

 
    }
}
