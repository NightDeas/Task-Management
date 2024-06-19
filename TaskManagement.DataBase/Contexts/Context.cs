using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.DataBase.Entities;

namespace TaskManagement.DataBase.Contexts
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HistoryChangeStatusTask> HistoryChangeStatusTask { get; set; }
        public DbSet<ProjectProjectAdministrator> ProjectProjectAdministrators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NM4JG25\\TEST;Initial Catalog=TaskManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<User>()
                .HasIndex(x => x.Login)
                .IsUnique(true);


            for (int i = 1; i < 6; i++)
            {

                modelBuilder.Entity<Project>().HasData(
                    new Project()
                    {
                        Id = i,
                        Name = $"Project{i}",
                    }
                    );
            }


            modelBuilder.Entity<Entities.Task>().HasData(
                new Entities.Task[]{
                new Entities.Task()
                {
                    Id = 1,
                    Name = "name1",
                    Description = "desc1",
                    Deadline = DateTime.Today,
                    ProjectId = 1,
                    UserId = 1,
                },
                 new Entities.Task()
                {
                    Id = 2,
                    Name = "name1",
                    Description = "desc1",

                    Deadline = DateTime.Today,
                    ProjectId = 1,
                    UserId = 1
                },
                  new Entities.Task()
                {
                    Id = 3,
                    Name = "name1",
                    Description = "desc1",
                      Deadline = DateTime.Today,
                    ProjectId = 1,
                    UserId = 1,
                },
                  new Entities.Task()
                {
                    Id = 4,
                    Name = "name1",
                    Description = "desc1",
                    Deadline = DateTime.Today,
                    ProjectId = 1,
                    UserId = 1,
                },
                 new Entities.Task()
                {
                    Id = 5,
                    Name = "name1",
                    Description = "desc1",

                    Deadline = DateTime.Today,
                    ProjectId = 1,
                    UserId = 1
                },
                  new Entities.Task()
                {
                    Id = 6,
                    Name = "name1",
                    Description = "desc1",
                      Deadline = DateTime.Today,
                    ProjectId = 1,
                    UserId = 1,
                }
            }
                );



            modelBuilder.Entity<Status>().HasData(
               new Status[]
               {
                    new Status()
                    {
                        Id = 1,
                        Name = "Открыта"
                    },
                    new Status()
                    {
                        Id = 2,
                        Name = "В работе"
                    },
                    new Status()
                    {
                        Id = 3,
                        Name = "На рассмотрении администратором"
                    },
                        new Status()
                    {
                        Id = 4,
                        Name = "Вернута администратором"
                    },
                        new Status()
                    {
                        Id = 5,
                        Name = "Закрыта"
                    },

               }
               );

            for (int i = 1; i < 6; i++)
            {
                modelBuilder.Entity<HistoryChangeStatusTask>().HasData(
                    new HistoryChangeStatusTask()
                    {
                        Id = i,
                        StatusId = Random.Shared.Next(1, 5),
                        Date = DateTime.Today,
                        TaskId = i
                    });
            }

            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role()
                    {
                        Id = 1,
                        Name = "Administrator"
                    },
                    new Role()
                    {
                        Id = 2,
                        Name = "Project Administrator"
                    },
                    new Role()
                    {
                        Id = 3,
                        Name = "Worker"
                    },
                }
                );

            int id = 1;
            for (int y = 0; y < 25; y++, id++)
            {
                modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id = id,
                        LastName = $"LastName{y}",
                        FirstName = $"FirstName{y}",
                        Patronymic = $"Patronymic{y}",
                        RoleId = 1,
                        Login = $"Login{id}",
                        Password = $"Password{id}",
                    }
                    );
            }

            for (int y = 0; y < 25; y++, id++)
            {
                modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id = id,
                        LastName = $"LastName{y}",
                        FirstName = $"FirstName{y}",
                        Patronymic = $"Patronymic{y}",
                        RoleId = 2,
                        Login = $"Login{id}",
                        Password = $"Password{id}",
                    }
                    );
            }
            for (int y = 0; y < 25; y++, id++)
            {
                modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id = id,
                        LastName = $"LastName{y}",
                        FirstName = $"FirstName{y}",
                        Patronymic = $"Patronymic{y}",
                        RoleId = 3,
                        Login = $"Login{id}",
                        Password = $"Password{id}",
                    }
                    );
            }
        }
    }
}
