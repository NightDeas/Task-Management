using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Desktop.Models
{
	public class EmployeeModel : UserModel
	{
		public int CountCompletedTasks { get; set; }
		public int CountNotCompletedTasks { get; set; }
	}
}
