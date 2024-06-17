using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class updateStartDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusId",
                value: 4);

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Created", "Deadline", "Deleted", "Description", "EndDate", "Name", "ProjectId", "StartDate", "Updated", "UserId" },
                values: new object[,]
                {
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), null, "desc1", null, "name1", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), null, "desc1", null, "name1", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), null, "desc1", null, "name1", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 }
                });

            migrationBuilder.InsertData(
                table: "HistoryChangeStatusTask",
                columns: new[] { "Id", "Date", "StatusId", "TaskId" },
                values: new object[,]
                {
                    { 4, new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 1, 4 },
                    { 5, new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 2, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusId",
                value: 2);
        }
    }
}
