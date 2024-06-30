using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Desktop.Models
{
	public class StatusModel
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public enum TaskStatuses
		{
			Created = 1,
			Work,
			Checking,
			CancelByAdmin,
			Closed,
		}

		public StatusModel ToModel(DataBase.Entities.Status status)
		{
			return new()
			{
				Id = status.Id,
				Name = status.Name,
			};
		}
	}
}
