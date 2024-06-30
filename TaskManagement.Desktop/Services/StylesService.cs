using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using TaskManagement.Desktop.UserControls;

namespace TaskManagement.Desktop.Services
{
	public static class StylesService
	{
		public static ProjectControl ProjectControl { get; set; }
		public static TaskControl TaskControl { get; set; }
		public static int TaskId { get; set; }
		public enum Controls
		{
			Project,
			Task
		}
		public static Style FindStyle(System.Windows.Controls.UserControl userControl, string key)
		{
			return (Style)userControl.Resources[key];
		}

		public static void SetActiveStyle(ProjectControl projectControl)
		{
			if (ProjectControl != null)
				ProjectControl.Border.Style = ProjectControl.Resources["DefaultStyle"] as Style;
			ProjectControl = projectControl;
			ProjectControl.Border.Style = (Style)ProjectControl.Resources["ActiveStyle"];
		}

		public static void SetActiveStyle(TaskControl taskControl)
		{
			if (TaskControl != null)
				TaskControl.Border.Style = TaskControl.Resources["DefaultStyle"] as Style;
			TaskControl = taskControl;
			TaskControl.Border.Style = (Style)TaskControl.Resources["ActiveStyle"];
		}

		public static void Reset()
		{
			if (ProjectControl != null)
				ProjectControl.Border.Style = ProjectControl.Resources["DefaultStyle"] as Style;
			if (TaskControl != null)
				TaskControl.Border.Style = TaskControl.Resources["DefaultStyle"] as Style;
		}

		public static void Reset(Controls controlType)
		{
			switch (controlType)
			{
				case Controls.Project:
					break;
				case Controls.Task:
					if (TaskControl != null)
						TaskControl.Border.Style = TaskControl.Resources["DefaultStyle"] as Style;
					break;
			}
		}

	}
}
