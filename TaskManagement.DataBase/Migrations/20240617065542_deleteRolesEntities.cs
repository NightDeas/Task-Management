using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class deleteRolesEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectProjectAdministrators_ProjectAdministrators_ProjectAdministratorId",
                table: "ProjectProjectAdministrators");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Administrator_AdministratorId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employees_EmployeeId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ProjectAdministrators_ProjectAdministratorId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProjectAdministrators");

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
                name: "IX_Tasks_EmployeeId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProjectAdministratorId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2024, 6, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectProjectAdministrators_Users_ProjectAdministratorId",
                table: "ProjectProjectAdministrators",
                column: "ProjectAdministratorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectProjectAdministrators_Users_ProjectAdministratorId",
                table: "ProjectProjectAdministrators");

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

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAdministrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAdministrators", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Administrator",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "StatusId" },
                values: new object[] { new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), 4 });

            migrationBuilder.InsertData(
                table: "ProjectAdministrators",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local));

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
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectProjectAdministrators_ProjectAdministrators_ProjectAdministratorId",
                table: "ProjectProjectAdministrators",
                column: "ProjectAdministratorId",
                principalTable: "ProjectAdministrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
