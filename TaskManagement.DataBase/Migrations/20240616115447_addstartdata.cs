using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class addstartdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrator_Users_UserId",
                table: "Administrator");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectAdministrators_Users_UserId",
                table: "ProjectAdministrators");

            migrationBuilder.DropIndex(
                name: "IX_ProjectAdministrators_UserId",
                table: "ProjectAdministrators");

            migrationBuilder.DropIndex(
                name: "IX_HistoryChanges_TaskId",
                table: "HistoryChanges");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Administrator_UserId",
                table: "Administrator");

            migrationBuilder.AddColumn<int>(
                name: "AdministratorId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectAdministratorId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Project1" },
                    { 2, false, "Project2" },
                    { 3, false, "Project3" },
                    { 4, false, "Project4" },
                    { 5, false, "Project5" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Открыта" },
                    { 2, "В работе" },
                    { 3, "На рассмотрении администратором" },
                    { 4, "Вернута администратором" },
                    { 5, "Закрыта" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdministratorId", "EmployeeId", "ProjectAdministratorId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AdministratorId", "EmployeeId", "ProjectAdministratorId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AdministratorId", "EmployeeId", "ProjectAdministratorId" },
                values: new object[] { null, null, null });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Created", "Deadline", "Deleted", "Description", "EndDate", "Name", "ProjectId", "StartDate", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), null, "desc1", null, "name1", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), null, "desc1", null, "name1", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), null, "desc1", null, "name1", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "HistoryChanges",
                columns: new[] { "Id", "Date", "StatusId", "TaskId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), 3, 1 },
                    { 2, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), 4, 2 },
                    { 3, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdministratorId",
                table: "Users",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProjectAdministratorId",
                table: "Users",
                column: "ProjectAdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryChanges_TaskId",
                table: "HistoryChanges",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Administrator_AdministratorId",
                table: "Users",
                column: "AdministratorId",
                principalTable: "Administrator",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ProjectAdministrators_ProjectAdministratorId",
                table: "Users",
                column: "ProjectAdministratorId",
                principalTable: "ProjectAdministrators",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Administrator_AdministratorId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ProjectAdministrators_ProjectAdministratorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AdministratorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployeeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProjectAdministratorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_HistoryChanges_TaskId",
                table: "HistoryChanges");

            migrationBuilder.DeleteData(
                table: "HistoryChanges",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HistoryChanges",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HistoryChanges",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProjectAdministratorId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAdministrators_UserId",
                table: "ProjectAdministrators",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoryChanges_TaskId",
                table: "HistoryChanges",
                column: "TaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_UserId",
                table: "Administrator",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Administrator_Users_UserId",
                table: "Administrator",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Users_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectAdministrators_Users_UserId",
                table: "ProjectAdministrators",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
