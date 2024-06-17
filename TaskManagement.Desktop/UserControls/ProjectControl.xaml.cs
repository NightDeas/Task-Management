﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManagement.Desktop.Models;
using TaskManagement.Desktop.Services;

namespace TaskManagement.Desktop.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ProjectControl.xaml
    /// </summary>
    public partial class ProjectControl : UserControl
    {
        public ProjectModel Project { get; set; }
        public ProjectControl(Models.ProjectModel project)
        {
            InitializeComponent();
            Project = project;
            DataContext = Project;
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ProjectsPageService projectsPageService = new ProjectsPageService(Project.Id);
            if (UserService.GetUser().Role.Id == 3) // employee
                projectsPageService.FillTasksInPage(UserService.GetUser().Id);
            else
                projectsPageService.FillTasksInPage();
        }
    }
}
