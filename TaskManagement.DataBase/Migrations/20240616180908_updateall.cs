using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class updateall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "HistoryChangeStatusTask",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmployeeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "EmployeeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "EmployeeId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Employees_EmployeeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Tasks");

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
                value: 1);
        }
    }
}
