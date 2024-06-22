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
        private static ProjectControl ProjectControl { get; set; }
        private static TaskControl TaskControl { get; set; }
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

        public static void Reset(Controls control)
        {
            switch (control)
            {
                case Controls.Project:
                    break;
                case Controls.Task:
                    TaskControl.Border.Style = TaskControl.Resources["DefaultStyle"] as Style;
                    break;
            }
        }

    }
}
