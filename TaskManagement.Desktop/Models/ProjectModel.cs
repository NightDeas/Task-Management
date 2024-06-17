using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Desktop.Models
{
    public class ProjectModel
    {
        private int countCompletedTasks;
        private int countTasks;
        private int countNotCompletedTasks;

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountCompletedTasks
        {
            get => countCompletedTasks; set
            {
                if (value < 0)
                    countCompletedTasks = 0;
                else
                    countCompletedTasks = value;
            }
        }
        public int CountTasks
        {
            get => countTasks; set
            {
                if (value < 0)
                    countTasks = 0;
                else
                    countTasks = value;
            }
        }
        public int CountNotCompletedTasks
        {
            get => countNotCompletedTasks; set
            {
                if (value < 0)
                    countNotCompletedTasks = 0;
                else
                    countNotCompletedTasks = value;
            }
        }

        public static DataBase.Entities.Project ToDbModel(Models.ProjectModel model)
        {
            return new DataBase.Entities.Project() { Name = model.Name };
        }
    }
}
