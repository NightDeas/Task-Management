using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.DataBase.Entities
{
    public class HistoryChangeStatusTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int StatusId { get; set; }
        public DateTime Date { get; set; }
        public virtual Task Task { get; set; }
        public virtual Status Status { get; set; }
    }
}
