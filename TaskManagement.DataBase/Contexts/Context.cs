using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualBasic;
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
			//optionsBuilder.UseSqlServer("Data Source=DESKTOP-3VRB7GU;Initial Catalog=TaskManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-NM4JG25\\TEST;Initial Catalog=TaskManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            optionsBuilder.UseSqlServer("Data Source=169.254.131.3;Initial Catalog=Burnasov_TaskManagement;User ID=stud;Password=Qwerty123456$;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
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
						LastName = SeedData.GetLastName(),
						FirstName = SeedData.GetFirstName(),
						Patronymic = SeedData.GetPatronymic(),
						Login = $"log{id}",
						Password = $"pas{id}",
						RoleId = 1,
					}
					);
			}

			for (int y = 0; y < 25; y++, id++)
			{
				modelBuilder.Entity<User>().HasData(
					new User()
					{
						Id = id,
						LastName = SeedData.GetLastName(),
						FirstName = SeedData.GetFirstName(),
						Patronymic = SeedData.GetPatronymic(),
						Login = $"log{id}",
						Password = $"pas{id}",
						RoleId = 2,
					}
					);
			}
			for (int y = 0; y < 25; y++, id++)
			{
				modelBuilder.Entity<User>().HasData(
					new User()
					{
						Id = id,
						LastName = SeedData.GetLastName(),
						FirstName = SeedData.GetFirstName(),
						Patronymic = SeedData.GetPatronymic(),
						Login = $"log{id}",
						Password = $"pas{id}",
						RoleId = 3,
					}
					);
			}

			modelBuilder.Entity<User>()
				.HasIndex(x => x.Login)
				.IsUnique(true);

			modelBuilder.Entity<Entities.Task>()
				.Property(x => x.Created)
				.HasDefaultValue(DateTime.Now);

			for (int i = 1; i <= 10; i++)
			{

				modelBuilder.Entity<Project>().HasData(
					new Project()
					{
						Id = i,
						Name = $"Project#{i}",
					}
					);
			}

			int employeeId = 75;
			for (int i = 1; i < 20; i++)
			{

				modelBuilder.Entity<Entities.Task>().HasData(
					new Entities.Task()
					{
						Id = i,
						Name = $"Task#{i}",
						Deadline = SeedData.GenerateDate(),
						Description = $"Description#{i}",
						ProjectId = Random.Shared.Next(1, 10),
						UserId = Random.Shared.Next(51, 74),
						StartDate = DateTime.Now,
						EndDate = DateTime.Now.AddDays(Random.Shared.Next(1,20)),
					}
					);
			}



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

			for (int i = 1; i < 20; i++)
			{
				modelBuilder.Entity<HistoryChangeStatusTask>().HasData(
					new HistoryChangeStatusTask()
					{
						Id = i,
						StatusId = Random.Shared.Next(1, 5),
						Date = SeedData.GenerateDate(),
						TaskId = i
					});
			}


		}
	}
}
