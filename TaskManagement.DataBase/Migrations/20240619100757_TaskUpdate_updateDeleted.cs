using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class TaskUpdate_updateDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Tasks"
                );

            migrationBuilder.AddColumn<bool>(
               name: "Deleted",
               table: "Tasks",
               type: "bit",
               defaultValue: false,
               nullable: false
               );


			//migrationBuilder.AlterColumn<bool>(
   //             name: "Deleted",
   //             table: "Tasks",
   //             type: "bit",
   //             nullable: false,
   //             defaultValue: false,
   //             oldClrType: typeof(DateTime),
   //             oldType: "datetime2",
   //             oldNullable: true);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), 4 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), 3 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), 3 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Deadline", "Deleted" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), false });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Deadline", "Deleted" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), false });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Deadline", "Deleted" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), false });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Deadline", "Deleted" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), false });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Deadline", "Deleted" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), false });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Deadline", "Deleted" },
                values: new object[] { new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AddColumn<DateTime>(
			   name: "Deleted",
			   table: "Tasks",
               type: "datetime2",
               nullable: true
			   );

			migrationBuilder.DropColumn(
			   name: "Deleted",
			   table: "Tasks"
			   );

			//migrationBuilder.AlterColumn<DateTime>(
   //             name: "Deleted",
   //             table: "Tasks",
   //             type: "datetime2",
   //             nullable: true,
   //             oldClrType: typeof(bool),
   //             oldType: "bit");

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 4 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 4 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Deadline", "Deleted" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Deadline", "Deleted" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Deadline", "Deleted" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Deadline", "Deleted" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Deadline", "Deleted" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Deadline", "Deleted" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), null });
        }
    }
}
